// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="IUserService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.User;

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
		Task<ResponseGenericDto<UserResponseDto>> ValidateUser(UserLoginDto user);
	}
}