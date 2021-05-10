// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="IUserService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Domain.DTO.User;
using System.Threading.Tasks;
using SlabCode.Domain.DTO;

namespace SlabCode.Application.Abstract
{
	/// <summary>
	/// Class IUserService.
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;UserResponseDto&gt;.</returns>
		Task<UserResponseDto> ValidateUser(UserLoginDto user);

		/// <summary>
		/// Creates the specified user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;UserResponseDto&gt;.</returns>
		Task<ResponseGenericDto<bool>> Create(UserCreateDto user);
		/// <summary>
		/// Updates the password.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> UpdatePassword(UserUpdatePasswordDto user);

		/// <summary>
		/// Users the inactivate.
		/// </summary>
		/// <param name="userInactivate">The userInactivate.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> UserInactivate(UserInactivateDto userInactivate);


		/// <summary>
		/// Notifiers the user administrador.
		/// </summary>
		/// <param name="body">The body.</param>
		/// <param name="subject">The subject.</param>
		/// <returns>Task.</returns>
		Task NotifierUserAdministrador(string body, string subject);
	}
}