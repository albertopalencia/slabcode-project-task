// ***********************************************************************
// Assembly         : PruebaTecnica.Application
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="PasswordService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.Extensions.Options;
using SlabCode.Application.Abstract;
using SlabCode.Infrastructure.Options;


namespace SlabCode.Application.Implements
{
 
	using System;
	using System.Linq;
	using System.Security.Cryptography;

	/// <summary>
	/// Class PasswordService.
	/// Implements the <see cref="IPasswordService" />
	/// Implements the <see cref="IPasswordService" />
	/// Implements the <see cref="IPasswordService" />
	/// </summary>
	/// <seealso cref="IPasswordService" />
	/// <seealso cref="IPasswordService" />
	/// <seealso cref="IPasswordService" />
	public class PasswordService : IPasswordService
	{
		/// <summary>
		/// The options
		/// </summary>
		private readonly PasswordOption _passwordOption;

		/// <summary>
		/// Initializes a new instance of the <see cref="PasswordService" /> class.
		/// </summary>
		/// <param name="passwordOption">The options.</param>
		public PasswordService(IOptions<PasswordOption> passwordOption)
		{
			_passwordOption = passwordOption.Value;
		}

		/// <summary>
		/// Checks the specified password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <param name="passwordEncrypt">The password.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="FormatException">Unexpected hash format</exception>
		public bool ValidateEnCrypt(string password, string passwordEncrypt)
		{
			var parts = passwordEncrypt.Split('.');
			if (parts.Length != 3)
			{
				throw new FormatException("Unexpected hash format");
			}

			var iterations = Convert.ToInt32(parts[0]);
			var salt = Convert.FromBase64String(parts[1]);
			var key = Convert.FromBase64String(parts[2]);

			using var algorithm = new Rfc2898DeriveBytes(
				password,
				salt,
				iterations
				);
			var keyToCheck = algorithm.GetBytes(_passwordOption.KeySize);
			return keyToCheck.SequenceEqual(key);
		}

		/// <summary>
		/// Hashes the specified password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>System.String.</returns>
		public string Encrypt(string password)
		{
			using var algorithm = new Rfc2898DeriveBytes(
				password,
				_passwordOption.SaltSize,
				_passwordOption.Iterations
				);
			var key = Convert.ToBase64String(algorithm.GetBytes(_passwordOption.KeySize));
			var salt = Convert.ToBase64String(algorithm.Salt);

			return $"{_passwordOption.Iterations}.{salt}.{key}";
		}





	}
}