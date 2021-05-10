// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="ProjectCreateDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using SlabCode.Common.Enumerations;
using SlabCode.Domain.Entities;

namespace SlabCode.Domain.DTO.Task
{
	/// <summary>
	/// Class ProjectCreateDto.
	/// </summary>
	public class TaskCreateDto
	{
		/// <summary>
		/// Gets or sets the name of the task.
		/// </summary>
		/// <value>The name of the task.</value>
		public string TaskName { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		/// <summary>
		/// Gets or sets the date execution.
		/// </summary>
		/// <value>The date execution.</value>
		public DateTime DateExecution { get; set; }
		/// <summary>
		/// Gets or sets the identifier proyect.
		/// </summary>
		/// <value>The identifier proyect.</value>
		public int ProjectId { get; set; }
		/// <summary>
		/// Gets or sets the state of the task.
		/// </summary>
		/// <value>The state of the task.</value>
		public TaskState TaskState { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="TaskCreateDto"/> to <see cref="TaskEntity"/>.
		/// </summary>
		/// <param name="task">The project.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator TaskEntity(TaskCreateDto task)
		{
			return new()
			{
				ProjectId = task.ProjectId,
				TaskName = task. TaskName,
				Description = task.Description,
				DateExecution = task.DateExecution,
				TaskState = TaskState.InProgress
			};
		}
	}
}