// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="UserCreateDto.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using SlabCode.Common.Enumerations;
using SlabCode.Domain.Entities;

namespace SlabCode.Domain.DTO.User
{
	/// <summary>
	/// Class UsuarioDto.
	/// </summary>

	public class UserCreateDto
	{
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; set; }
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email { get; set; }
		/// <summary>
		/// Gets or sets the active.
		/// </summary>
		/// <value>The active.</value>
		public UserState Active { get; set; }
		/// <summary>
		/// Gets or sets the role.
		/// </summary>
		/// <value>The role.</value>
		public RoleType Role { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="UserCreateDto"/> to <see cref="UserEntity"/>.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator UserEntity(UserCreateDto user)
		{
			return new()
			{
				
				Password = user.Password,
				UserName = user.UserName,
				Email = user.Email,
				Role = user.Role,
				Active = user.Active
			};
		}
	}
}