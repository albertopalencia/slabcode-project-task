// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="ProyectEntity.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Common.Enumerations;
using System;
using System.Collections.Generic;

namespace SlabCode.Domain.Entities
{
	/// <summary>
	/// Class ProyectEntity.
	/// Implements the <see cref="SlabCode.Domain.Entities.Entity" />
	/// </summary>
	/// <seealso cref="SlabCode.Domain.Entities.Entity" />
	public class ProyectEntity : Entity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProyectEntity"/> class.
		/// </summary>
		public ProyectEntity()
		{
			Tasks = new HashSet<TaskEntity>();
		}

		/// <summary>
		/// Gets or sets the name of the proyect.
		/// </summary>
		/// <value>The name of the proyect.</value>
		public string ProyectName { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		/// <summary>
		/// Gets or sets the date initialize.
		/// </summary>
		/// <value>The date initialize.</value>
		public DateTime DateInit { get; set; }
		/// <summary>
		/// Gets or sets the date ended.
		/// </summary>
		/// <value>The date ended.</value>
		public DateTime? DateEnded { get; set; }
		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		public int State { get; set; }
		/// <summary>
		/// Gets or sets the state of the proyect.
		/// </summary>
		/// <value>The state of the proyect.</value>
		public ProyectState ProyectState { get; set; }
		/// <summary>
		/// Gets or sets the tasks.
		/// </summary>
		/// <value>The tasks.</value>
		public ICollection<TaskEntity> Tasks { get; set; }
	}
}