// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-08-2021
// ***********************************************************************
// <copyright file="UserUpdatePasswordDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Domain.DTO.User
{
	/// <summary>
	/// Class UserUpdatePasswordDto.
	/// </summary>
	public class UserUpdatePasswordDto
	{
		/// <summary>
		/// Gets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; init; }
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; init; }
		/// <summary>
		/// Creates new password.
		/// </summary>
		/// <value>The new password.</value>
		public string NewPassword { get; init; }
	}
}