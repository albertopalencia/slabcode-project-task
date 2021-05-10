// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="ProjectIdResultDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using SlabCode.Common.Enumerations;
using SlabCode.Domain.Entities;

namespace SlabCode.Domain.DTO.Project
{
	/// <summary>
	/// Class ProjectIdResultDto.
	/// </summary>
	public class ProjectIdResultDto
	{
		/// <summary>
		/// Gets or sets the project identifier.
		/// </summary>
		/// <value>The project identifier.</value>
		public int ProjectId { get; set; }

		/// <summary>
		/// Gets or sets the name of the project.
		/// </summary>
		/// <value>The name of the project.</value>
		public string ProjectName { get; set; }

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
		public DateTime? DateEnd { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		public ProjectState State { get; set; }

		public static implicit operator ProjectIdResultDto(ProjectEntity project)
		{
			return new ()
			{
				ProjectId = project.Id,
				ProjectName = project.ProjectName,
				Description = project.Description,
				DateInit = project.DateInit,
				DateEnd = project.DateEnd,
				State = project.State
			};
		}
	}
}