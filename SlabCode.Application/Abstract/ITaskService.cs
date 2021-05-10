// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="ITaskService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.Task;
using System.Threading.Tasks;
using SlabCode.Domain.Entities;

namespace SlabCode.Application.Abstract
{
	/// <summary>
	/// Interface ITaskService
	/// </summary>
	public interface ITaskService
	{
		/// <summary>
		/// Removes the task.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		Task<ResponseGenericDto<bool>> RemoveTask(int id);

		/// <summary>
		/// Updates the task.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="task">The task.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		Task<object> UpdateTask(int id, TaskUpdateDto task);

		/// <summary>
		/// Creates the task.
		/// </summary>
		/// <param name="task">The task.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		Task<object> CreateTask(TaskCreateDto task);

		/// <summary>
		/// Gets the by task identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		Task<TaskEntity> GetByTaskId(int id);

		/// <summary>
		/// Tasks the complete.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		Task<ResponseGenericDto<bool>> TaskComplete(int id);
	}
}