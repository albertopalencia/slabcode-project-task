// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="ProjectUpdateDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace SlabCode.Domain.DTO.Project
{
	/// <summary>
	/// Class ProjectUpdateDto.
	/// </summary>
	public class ProjectUpdateDto
	{
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
		/// Gets or sets the date ended.
		/// </summary>
		/// <value>The date ended.</value>
		public DateTime DateEnd { get; set; }
	}
}