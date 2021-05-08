// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="PasswordOption.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace SlabCode.Infrastructure.Options
{
	/// <summary>
	/// Class PasswordOption.
	/// </summary>
	public class PasswordOption
	{
		/// <summary>
		/// Gets or sets the size of the salt.
		/// </summary>
		/// <value>The size of the salt.</value>
		public int SaltSize { get; set; }

		/// <summary>
		/// Gets or sets the size of the key.
		/// </summary>
		/// <value>The size of the key.</value>
		public int KeySize { get; set; }

		/// <summary>
		/// Gets or sets the iterations.
		/// </summary>
		/// <value>The iterations.</value>
		public int Iterations { get; set; }
	}
}