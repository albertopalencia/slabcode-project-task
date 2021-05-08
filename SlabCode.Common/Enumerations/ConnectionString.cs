// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="ConnectionStringEnum.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace SlabCode.Common.Enumerations
{

	/// <summary>
	/// Class ConnectionStringEnum.
	/// Implements the <see cref="SlabCode.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="SlabCode.Common.Enumerations.Enumeration" />
	public class ConnectionString : Enumeration
	{
		/// <summary>
		/// The prueba tecnica
		/// </summary>
		private static readonly ConnectionString _SlabCode = new (1, "ConnectionStrings:SlabCode");

		/// <summary>
		/// Gets the prueba tecnica.
		/// </summary>
		/// <value>The prueba tecnica.</value>
		public static ConnectionString SlabCode { get => _SlabCode; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionString" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public ConnectionString(int id, string name) : base(id, name)
		{
		}
	}
}