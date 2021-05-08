// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="TaskState.cs" company="SlabCode.Common">
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
	public class TaskState : Enumeration
	{

		/// <summary>
		/// The visitante
		/// </summary>
		private static TaskState _inProgress = new (1, "En Proceso");
		/// <summary>
		/// The asistente
		/// </summary>
		private static TaskState _done = new(2, "Finalizado");

		public static TaskState InProgress => _inProgress;
		public static TaskState Done => _done;
		
 
		public TaskState(int id, string name) : base(id, name)
		{

		}
	}

}