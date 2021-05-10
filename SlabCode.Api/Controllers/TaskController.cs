// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="TaskController.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SlabCode.Domain.DTO.Task;

namespace SlabCode.Api.Controllers
{
	/// <summary>
	/// Class TaskController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Authorize(Roles = "Administrador,Operador")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		/// <summary>
		/// The task service
		/// </summary>
		private readonly ITaskService _taskService;

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskController" /> class.
		/// </summary>
		/// <param name="taskService">The task service.</param>
		public TaskController(ITaskService taskService)
		{
			_taskService = taskService;
		}

		/// <summary>
		/// Gets the project by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet("GetByTaskId:{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<TaskListDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> GetProjectById(int id)
		{
			var response = await _taskService.GetByTaskId(id);
			return Ok(response);
		}

		/// <summary>
		/// Creates the specified project.
		/// </summary>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost("Create")]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Create([FromBody] TaskCreateDto project)
		{
			var response = await _taskService.CreateTask(project);
			return CreatedAtAction("Create", response);
		}

		/// <summary>
		/// Updates the task.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut("UpdateTask:{id}")]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskUpdateDto project)
		{
			var response = await _taskService.UpdateTask(id, project);
			return Ok(response);
		}

		/// <summary>
		/// Tasks the complete.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut("TaskComplete:{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> TaskComplete(int id)
		{
			var response = await _taskService.TaskComplete(id);
			return Ok(response);
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
			var response = await _taskService.RemoveTask(id);
			return Ok(response);
		}
	}
}