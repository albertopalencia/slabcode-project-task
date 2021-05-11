// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-11-2021
// ***********************************************************************
// <copyright file="ProjectListDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Domain.Entities;
using System;

namespace SlabCode.Domain.DTO.Project
{
	/// <summary>
	/// Class ProjectListDto.
	/// </summary>
	public class ProjectListDto
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
		public string State { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="ProjectEntity" /> to <see cref="ProjectListDto" />.
		/// </summary>
		/// <param name="project">The project.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ProjectListDto(ProjectEntity project)
		{
			return new()
			{
				ProjectId = project.Id,
				ProjectName = project.ProjectName,
				Description = project.Description,
				DateInit = project.DateInit,
				DateEnd = project.DateEnd,
				State = project.State.Name
			};
		}
	}
}