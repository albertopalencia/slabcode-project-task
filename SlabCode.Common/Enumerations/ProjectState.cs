// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="ProjectState.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace SlabCode.Common.Enumerations
{


	/// <summary>
	/// Class ProjectState.
	/// Implements the <see cref="SlabCode.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="SlabCode.Common.Enumerations.Enumeration" />
	public class ProjectState : Enumeration
	{

		/// <summary>
		/// The visitante
		/// </summary>
		private static ProjectState _inProgress = new (1, "En Proceso");
		/// <summary>
		/// The asistente
		/// </summary>
		private static ProjectState _done = new(2, "Finalizado");

		public static ProjectState InProgress => _inProgress;
		public static ProjectState Done => _done;
		
 
		public ProjectState(int id, string name) : base(id, name)
		{

		}
	}

}