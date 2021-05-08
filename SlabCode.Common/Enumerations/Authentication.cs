// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="Authentication.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Common.Enumerations
{
	/// <summary>
	/// Class Authentication.
	/// Implements the <see cref="SlabCode.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="SlabCode.Common.Enumerations.Enumeration" />
	public class Authentication : Enumeration
	{
		/// <summary>
		/// The editor
		/// </summary>
		private static readonly Authentication _editor = new(0, "Authentication:Issuer");

		/// <summary>
		/// The llave secreta
		/// </summary>
		private static readonly Authentication _keySecret = new(1, "Authentication:SecretKey");

		/// <summary>
		/// The audiencia
		/// </summary>
		private static readonly Authentication _audience = new(2, "Authentication:Audience");

		/// <summary>
		/// The minutos token
		/// </summary>
		private static readonly Authentication _minuteToken = new(3, "Authentication:MinutesToken");
		

		/// <summary>
		/// Gets the editor.
		/// </summary>
		/// <value>The editor.</value>
		public static Authentication Editor { get => _editor; }

		/// <summary>
		/// Gets the llave secreta.
		/// </summary>
		/// <value>The llave secreta.</value>
		public static Authentication SecretyKey { get => _keySecret; }

		/// <summary>
		/// Gets the Audience.
		/// </summary>
		/// <value>The Audience.</value>
		public static Authentication Audience { get => _audience; }

		/// <summary>
		/// Gets the minutos token.
		/// </summary>
		/// <value>The minutos token.</value>
		public static Authentication MinutesToken { get => _minuteToken; }

		

		/// <summary>
		/// Initializes a new instance of the <see cref="Authentication" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public Authentication(int id, string name) : base(id, name)
		{
		}
	}
}