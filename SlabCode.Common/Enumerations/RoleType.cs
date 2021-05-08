// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="RoleTypeEnum.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace SlabCode.Common.Enumerations
{

	/// <summary>
	/// Class RolTypeEnum.
	/// Implements the <see cref="Enumeration" />
	/// Implements the <see cref="SlabCode.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="SlabCode.Common.Enumerations.Enumeration" />
	/// <seealso cref="Enumeration" />
	public class RoleType : Enumeration
	{

		/// <summary>
		/// The visitante
		/// </summary>
		private static   RoleType _administrator = new (1, "Administrador");
		/// <summary>
		/// The asistente
		/// </summary>
		private static   RoleType _operator = new(2, "Operador");

		public static RoleType Operator => _operator;
		public static RoleType Administrator => _operator;
		

		
		/// <summary>
		/// Initializes a new instance of the <see cref="RoleType"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public RoleType(int id, string name) : base(id, name)
		{

		}
	}

}