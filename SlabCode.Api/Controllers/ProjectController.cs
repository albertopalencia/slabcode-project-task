// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="ProjectController.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.Project;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SlabCode.Api.Controllers
{
	/// <summary>
	/// Class ProjectController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Authorize(Roles = "Administrador,Operador")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		/// <summary>
		/// The project service
		/// </summary>
		private readonly IProjectService _projectService;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectController" /> class.
		/// </summary>
		/// <param name="projectService">The project service.</param>
		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		/// <summary>
		/// Projectses the specified page.
		/// </summary>
		/// <param name="take">The take.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet("Projects")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<ProjectListDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Projects(int take)
		{
			var projects = await _projectService.Projects(take);
			return Ok(projects);
		}


		/// <summary>
		/// Projectses the specified page.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet("GetProjectById")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<ProjectListDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> GetProjectById(int id)
		{
			var projects = await _projectService.GetByProjectId(id);
			return Ok(projects);
		}


		/// <summary>
		/// Creates the specified project.
		/// </summary>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost("Create")]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Create([FromBody] ProjectCreateDto project)
		{
			var projectCreate = await _projectService.CreateProject(project);
			return CreatedAtAction("Create", projectCreate);
		}



		/// <summary>
		/// Updates the project.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost("UpdateProject:{id}")]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto project)
		{
			var response = await _projectService.UpdateProject(id, project);
			return Ok(response);
		}


		/// <summary>
		/// Projects the complete.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut("ProjectComplete:{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ProjectComplete(int id)
		{
			var projectComplete = await _projectService.ProjectComplete(id);
			return Ok(projectComplete);
		}


		/// <summary>
		/// Removes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Remove(int id)
		{
			var projectRemoved = await _projectService.RemoveProject(id);
			return Ok(projectRemoved);
		}
	}
}