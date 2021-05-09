// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-08-2021
// ***********************************************************************
// <copyright file="UserState.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace SlabCode.Common.Enumerations
{


	/// <summary>
	/// Class TaskStateEnum.
	/// Implements the <see cref="SlabCode.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="SlabCode.Common.Enumerations.Enumeration" />
	public class UserState : Enumeration
	{

		/// <summary>
		/// The visitante
		/// </summary>
		private static UserState _active = new (1, "Habilitado");
		/// <summary>
		/// The asistente
		/// </summary>
		private static UserState _inactive = new(0, "InHabilitado");

		public static UserState Active => _active;
		public static UserState Inactive => _inactive;
		
 
		public UserState(int id, string name) : base(id, name)
		{

		}
	}

}