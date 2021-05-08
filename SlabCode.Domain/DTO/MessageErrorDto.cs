// ***********************************************************************
// Assembly         : Slabcode.Domain
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="MessageError.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Domain.DTO
{
	/// <summary>
	/// Class MessageError.
	/// </summary>
	public class MessageErrorDto
	{
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }
		/// <summary>
		/// Gets or sets the property.
		/// </summary>
		/// <value>The property.</value>
		public string Property { get; set; }
	}
}