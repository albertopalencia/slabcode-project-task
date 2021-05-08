// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="UserService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using SlabCode.Application.Abstract;
using SlabCode.Common.Enumerations;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.User;
using SlabCode.Domain.Entities;
using SlabCode.Infrastructure.Interfaces.Repositories;

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
		/// The repository
		/// </summary>
		private readonly IUserRepository _repository;

		/// <summary>
		/// The password service
		/// </summary>
		private readonly IPasswordService _passwordService;
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
		public async Task<ResponseGenericDto<UserResponseDto>> ValidateUser(UserLoginDto user)
		{
			var userEntity = await GetByUserName(user.UserName);
			UserIsActive(userEntity);
			if (!_passwordService.ValidateEnCrypt(user.Password, userEntity.Password))
			{
				throw new Exception($"el usuario {user.UserName} no esta habilitado ");
			}

			return new ResponseGenericDto<UserResponseDto> {Result = userEntity, Success = true};
		}


		/// <summary>
		/// Gets the name of the by user.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <returns>Task&lt;UserEntity&gt;.</returns>
		/// <exception cref="ArgumentNullException">user not found {userName}</exception>
		private async Task<UserEntity> GetByUserName(string userName)
		{
			var userExists = await _repository.FirstOrDefaultAsync(f => f.UserName == userName );
			if (userExists is null)
			{
				throw new ArgumentNullException($" Usuario no valido: {userName}");
			}

			return userExists;
		}

		/// <summary>
		/// Users the is active.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <exception cref="Exception">el usuario {user.UserName} no esta habilitado</exception>
		private static void UserIsActive(UserEntity user)
		{  
			if (UserState.Inactive.CompareTo(user.Active) == decimal.Zero )
			{
				throw new Exception($"el usuario {user.UserName} no esta habilitado ");
			}
			 
		}
	}
}