// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-08-2021
// ***********************************************************************
// <copyright file="PasswordUtilities.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace SlabCode.Common.Utilities
{
	/// <summary>
	/// Class PasswordUtilities.
	/// </summary>
	public class PasswordUtilities
	{
		/// <summary>
		/// Generates the randon password.
		/// </summary>
		/// <returns>System.String.</returns>
		public static string generateRandonPassword()
		{
			var randon = new Random();
			const string words = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.*&()!$#@";
			var wordLength = words.Length;
			var newPassword = string.Empty;
			const int passwordLength = 10;
			for (var i = 0; i < passwordLength; i++)
			{
				var characters = words[randon.Next(wordLength)];
				newPassword += characters;
			}
			 
			return newPassword;
		}
	}
}