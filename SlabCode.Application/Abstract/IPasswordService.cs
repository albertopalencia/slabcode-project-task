// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="IPasswordService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Application.Abstract
{
	/// <summary>
	/// Interface IPasswordService
	/// </summary>
	public interface IPasswordService
	{
		/// <summary>
		/// Hashes the specified password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>System.String.</returns>
		string Encrypt(string password);

		/// <summary>
		/// Checks the specified hash.
		/// </summary>
		/// <param name="password">The hash.</param>
		/// <param name="passwordEncrypt">The password.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		bool ValidateEnCrypt(string password, string passwordEncrypt);
		 
	}
}