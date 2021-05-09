// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-08-2021
// ***********************************************************************
// <copyright file="AuthenticationOption.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Infrastructure.Options
{
	/// <summary>
	/// Class AuthenticationOption.
	/// </summary>
	public class AuthenticationOption
	{
		/// <summary>
		/// Gets or sets the secret key.
		/// </summary>
		/// <value>The secret key.</value>
		public string SecretKey { get; set; }
		/// <summary>
		/// Gets or sets the issuer.
		/// </summary>
		/// <value>The issuer.</value>
		public string Issuer { get; set; }
		/// <summary>
		/// Gets or sets the audience.
		/// </summary>
		/// <value>The audience.</value>
		public string Audience { get; set; }
		/// <summary>
		/// Gets or sets the audience.
		/// </summary>
		/// <value>The audience.</value>
		public int Minutes { get; set; }

		 
	}
}