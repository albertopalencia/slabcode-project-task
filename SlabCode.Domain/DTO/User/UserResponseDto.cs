// ***********************************************************************
// Assembly         : Slabcode.Domain
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="UserResponseDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using SlabCode.Domain.Entities;

namespace SlabCode.Domain.DTO.User
{
	/// <summary>
	/// Class UserResponseDto.
	/// </summary>
	public class UserResponseDto
	{
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }

		/// <summary>
		/// Gets or sets the rol.
		/// </summary>
		/// <value>The rol.</value>
		public string RolType { get; set; }


		/// <summary>
		/// Performs an implicit conversion from <see cref="UserEntity"/> to <see cref="UserResponseDto"/>.
		/// </summary>
		/// <param name="userEntity">The user entity.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator UserResponseDto(UserEntity userEntity) =>
			new()
			{
				UserName = userEntity.UserName,
				RolType = userEntity.Role.Name
			};
		 
	}
}