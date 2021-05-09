﻿// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-08-2021
// ***********************************************************************
// <copyright file="UserService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Application.Abstract;
using SlabCode.Common.Enumerations;
using SlabCode.Common.Resources;
using SlabCode.Common.Utilities;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.User;
using SlabCode.Domain.Entities;
using SlabCode.Infrastructure.Interfaces.Repositories;
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
		/// Initializes a new instance of the <see cref="UserService" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="passwordService">The password service.</param>
		public UserService(IUserRepository repository, IPasswordService passwordService)
		{
			_repository = repository;
			_passwordService = passwordService;
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
			if (!_passwordService.ValidateEnCrypt(user.Password, userEntity.Password))
			{
				GenerateException(UserMessage.UsuarioContransenaInvalida);
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
			if (userCreate != null) GenerateException(UserMessage.UsuarioYaExiste);
			userCreate.Password = _passwordService.Encrypt(PasswordUtilities.generateRandonPassword());
			await _repository.AddAsync(user);
			return new ResponseGenericDto<bool> { Success = true };
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
			if (userUpdate is null) GenerateException(UserMessage.NoExisteUsuario);
			if (userUpdate.RequireChangePassword) GenerateException(UserMessage.UsuarioNoRequiereCambiarContrasena);
			
			var validatePassword = _passwordService.ValidateEnCrypt(user.Password, userUpdate.Password);

			userUpdate.Password = _passwordService.Encrypt(user.NewPassword);
			userUpdate.DateChangePassword = DateTime.Now;
			userUpdate.RequireChangePassword = false;
			return new ResponseGenericDto<bool>();
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
			if (user is null) GenerateException(UserMessage.NoExisteUsuario);
			UserIsActive(user.Active);

			user.Active = UserState.Inactive;
			_repository.Update(user);
			return new ResponseGenericDto<bool> { Result = true, Success = true, Message = UserMessage.DeshabilitarUsuario };
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
				GenerateException(UserMessage.UsuarioDeshabilitado);
			}
		}
	}
}