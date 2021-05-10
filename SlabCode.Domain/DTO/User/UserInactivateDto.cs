// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="UserInactivateDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using SlabCode.Common.Enumerations;

namespace SlabCode.Domain.DTO.User
{
	/// <summary>
	/// Class UserInactivateDto.
	/// </summary>
	public class UserInactivateDto
	{
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }

		/// <summary>
		/// Gets or sets the activate.
		/// </summary>
		/// <value>The activate.</value>
		public UserState Activate { get; set; }
	}
}