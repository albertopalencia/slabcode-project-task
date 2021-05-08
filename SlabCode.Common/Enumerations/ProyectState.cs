// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="ProyectState.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace SlabCode.Common.Enumerations
{


	/// <summary>
	/// Class ProyectState.
	/// Implements the <see cref="SlabCode.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="SlabCode.Common.Enumerations.Enumeration" />
	public class ProyectState : Enumeration
	{

		/// <summary>
		/// The visitante
		/// </summary>
		private static ProyectState _inProgress = new (1, "En Proceso");
		/// <summary>
		/// The asistente
		/// </summary>
		private static ProyectState _done = new(2, "Finalizado");

		public static ProyectState InProgress => _inProgress;
		public static ProyectState Done => _done;
		
 
		public ProyectState(int id, string name) : base(id, name)
		{

		}
	}

}