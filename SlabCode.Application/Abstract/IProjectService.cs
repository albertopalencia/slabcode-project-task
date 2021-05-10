// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="IProjectService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using SlabCode.Domain.DTO.Project;
using System.Threading.Tasks;
using SlabCode.Domain.DTO;

namespace SlabCode.Application.Abstract
{
	/// <summary>
	/// Interface IProjectService
	/// </summary>
	public interface IProjectService
	{
		/// <summary>
		/// Projectses the specified page.
		/// </summary>
		/// <param name="take">The take.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;ProjectListDto&gt;&gt;.</returns>
		Task<ResponseGenericDto<List<ProjectListDto>>> Projects(int take);
		/// <summary>
		/// Creates the project.
		/// </summary>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> CreateProject(ProjectCreateDto project);
		/// <summary>
		/// Updates the project.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> UpdateProject(int projectId, ProjectUpdateDto project);
		/// <summary>
		/// Gets the by project identifier.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;ProjectIdResultDto&gt;&gt;.</returns>
		Task<ResponseGenericDto<ProjectIdResultDto>> GetByProjectId(int projectId);
		/// <summary>
		/// Removes the project.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> RemoveProject(int projectId);

		/// <summary>
		/// Projects the complete.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> ProjectComplete(int projectId);
	}
}