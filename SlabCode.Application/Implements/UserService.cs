// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="UserService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Options;
using SlabCode.Application.Abstract;
using SlabCode.Application.DTO.Mail;
using SlabCode.Common.Enumerations;
using SlabCode.Common.Resources;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.User;
using SlabCode.Domain.Entities;
using SlabCode.Infrastructure.Interfaces.Repositories;
using SlabCode.Infrastructure.Options;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SlabCode.Application.Implements
{
	/// <summary>
	/// Class UserService.
	/// Implements the <see cref="SlabCode.Application.Abstract.IUserService" />
	/// </summary>
	/// <seealso cref="SlabCode.Application.Abstract.IUserService" />
	public class UserService : IUserService
	{
		/// <summary>
		/// The password service
		/// </summary>
		private readonly IPasswordService _passwordService;

		/// <summary>
		/// The repository
		/// </summary>
		private readonly IUserRepository _repository;

		/// <summary>
		/// The mail service
		/// </summary>
		private readonly IMailService _mailService;

		/// <summary>
		/// The mail configuration
		/// </summary>
		private readonly MailConfigurationOption _mailConfiguration;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="passwordService">The password service.</param>
		/// <param name="mailService">The mail service.</param>
		/// <param name="mailConfiguration">The mail configuration.</param>
		public UserService(IUserRepository repository, IPasswordService passwordService,
			IMailService mailService, IOptions<MailConfigurationOption> mailConfiguration)
		{
			_repository = repository;
			_passwordService = passwordService;
			_mailService = mailService;
			_mailConfiguration = mailConfiguration.Value;
		}

		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;UserResponseDto&gt;.</returns>
		/// <exception cref="ArgumentNullException">user not found {user.UserName}</exception>
		/// <exception cref="Exception">el usuario {user.UserName} no esta habilitado</exception>
		public async Task<UserResponseDto> ValidateUser(UserLoginDto user)
		{
			var userEntity = await FindByUserName(user.UserName);
			if (userEntity is null) GenerateException(nameof(user));
			UserIsActive(userEntity.Active);
			if (userEntity.RequireChangePassword) GenerateException(UserMessageResource.UsuarioRequiereCambiarContrasena);

			if (!_passwordService.ValidateEnCrypt(user.Password, userEntity.Password))
			{
				GenerateException(UserMessageResource.UsuarioContransenaInvalida);
			}

			return userEntity;
		}

		/// <summary>
		/// Creates the specified user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;UserResponseDto&gt;.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ResponseGenericDto<bool>> Create(UserCreateDto user)
		{
			var userCreate = await FindByUserName(user.UserName);
			if (userCreate != null) GenerateException(UserMessageResource.UsuarioYaExiste);
			UserEntity userEntity = user;
			await _repository.AddAsync(userEntity);

			var body = UserMessageResource.EnviarCorreoCambioContrasena.Replace("{a}", userEntity.Password);
			await SendUserEmail(user.Email, body, UserMessageResource.Cambio_Contraseña);

			return new ResponseGenericDto<bool> { Success = true, Message = UserMessageResource.UsuarioCreadoExitosamente };
		}

		/// <summary>
		/// Finds the name of the by user.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <returns>Task&lt;UserEntity&gt;.</returns>
		internal async Task<UserEntity> FindByUserName(string userName)
		{
			return await FirstUserOrDefaultAsync(u => u.UserName == userName.ToLower());
		}

		/// <summary>
		/// Updates the password.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		public async Task<ResponseGenericDto<bool>> UpdatePassword(UserUpdatePasswordDto user)
		{
			var userUpdate = await FindByUserName(user.UserName);
			if (userUpdate is null) GenerateException(UserMessageResource.NoExisteUsuario);
			if (!string.Equals(userUpdate.Password, user.Password))
			{
				GenerateException(UserMessageResource.UsuarioRequiereCambiarContrasena);
			}

			userUpdate.Password = _passwordService.Encrypt(user.NewPassword);
			userUpdate.DateChangePassword = DateTime.Now;
			userUpdate.RequireChangePassword = false;
			userUpdate.Active = UserState.Active;

			_repository.Update(userUpdate);
			return new ResponseGenericDto<bool> { Success = true, Message = UserMessageResource.ContrasenaCambiada };
		}

		/// <summary>
		/// Users the inactivate.
		/// </summary>
		/// <param name="userInactivate">Name of the user.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ResponseGenericDto<bool>> UserInactivate(UserInactivateDto userInactivate)
		{
			var user = await FirstUserOrDefaultAsync(u => u.UserName == userInactivate.UserName);
			if (user is null) GenerateException(UserMessageResource.NoExisteUsuario);
			user.Active = userInactivate.Activate;
			_repository.Update(user);
			var message = userInactivate.Activate == UserState.Inactive
				? UserMessageResource.DeshabilitarUsuario
				: UserMessageResource.UsuarioHabilitado;

			return new ResponseGenericDto<bool> { Result = true, Success = true, Message = UserMessageResource.DeshabilitarUsuario };
		}

		/// <summary>
		/// Notifiers the user administrador.
		/// </summary>
		/// <param name="body">The body.</param>
		/// <param name="subject">The subject.</param>
		public async Task NotifierUserAdministrador(string body, string subject)
		{
			var users = await _repository.GetAllAsync(g => g.Active == UserState.Active && g.Role == RoleType.Administrator);
			foreach (var user in users)
			{
				await SendUserEmail(user.Email, body, subject);
			}
		}

		/// <summary>
		/// Gets the name of the by user.
		/// </summary>
		/// <param name="userFunc">The user function.</param>
		/// <returns>Task&lt;UserEntity&gt;.</returns>
		internal async Task<UserEntity> FirstUserOrDefaultAsync(Expression<Func<UserEntity, bool>> userFunc)
		{
			return await _repository.FirstOrDefaultAsync(userFunc);
		}

		/// <summary>
		/// Generates the exception.
		/// </summary>
		/// <param name="error">The error.</param>
		/// <exception cref="Exception"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		internal static void GenerateException(string error) => throw new Exception(error);

		/// <summary>
		/// Users the is active.
		/// </summary>
		/// <param name="active">The active.</param>
		internal static void UserIsActive(UserState active)
		{
			if (UserState.Inactive.CompareTo(active) == decimal.Zero)
			{
				GenerateException(UserMessageResource.UsuarioDeshabilitado);
			}
		}

		/// <summary>
		/// Sends the user email.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <param name="body">The body.</param>
		/// <param name="subject">The subject.</param>
		private async Task SendUserEmail(string email, string body, string subject)
		{
			var mailConfig = new MailConfigDto
			{
				Subject = subject,
				From = _mailConfiguration.From,
				To = email,
				Body = body,
				User = _mailConfiguration.Username,
				Password = _mailConfiguration.Password,
				Port = _mailConfiguration.Port,
				Host = _mailConfiguration.Host,
				EnableSsl = _mailConfiguration.EnableSsl
			};
			await _mailService.SendMailAsync(mailConfig);
		}
	}
}