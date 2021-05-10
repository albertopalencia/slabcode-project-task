// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="TaskService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Application.Abstract;
using SlabCode.Common.Extensions;
using SlabCode.Common.Resources;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.Task;
using SlabCode.Infrastructure.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using SendGrid;
using SlabCode.Common.Enumerations;
using SlabCode.Domain.Entities;

namespace SlabCode.Application.Implements
{
	/// <summary>
	/// Class TaskService.
	/// Implements the <see cref="SlabCode.Application.Abstract.ITaskService" />
	/// </summary>
	/// <seealso cref="SlabCode.Application.Abstract.ITaskService" />
	public class TaskService : ITaskService
	{

		/// <summary>
		/// The repository
		/// </summary>
		private readonly ITaskRepository _repository;


		/// <summary>
		/// The project repository
		/// </summary>
		private readonly IProjectRepository _projectRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskService" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="projectRepository">The project repository.</param>
		public TaskService(ITaskRepository repository, IProjectRepository projectRepository)
		{
			_repository = repository;
			_projectRepository = projectRepository;
		}


		/// <summary>
		/// Removes the task.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<ResponseGenericDto<bool>> RemoveTask(int id)
		{
			var task = await GetByTaskId(id);
			
			_repository.Remove(task);

			return new ResponseGenericDto<bool>
			{
				Success = true,
				Message = TaskMessageResource.MensajeTareaEliminada
			};
		}

		/// <summary>
		/// Updates the task.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="task">The task.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		/// <exception cref="Exception"></exception>
		public async Task<object> UpdateTask(int id, TaskUpdateDto task)
		{
			var taskEntity = await _repository.FirstOrDefaultAsync(f => f.Id == id);
			if (taskEntity is null)
			{
				throw new Exception(TaskMessageResource.MensajeTareaNoExiste);
			}

			DateExecutionInRange(task.DateExecution, taskEntity.Project.DateInit, taskEntity.Project.DateEnd.Value);

			taskEntity.Description = task.Description;
			taskEntity.TaskName = task.TaskName;
			taskEntity.DateExecution = task.DateExecution;

			_repository.Update(taskEntity);

			return new ResponseGenericDto<bool>
				{ Success = true, Message = TaskMessageResource.MensajeTareaActualizada };
		}

		/// <summary>
		/// Creates the task.
		/// </summary>
		/// <param name="task">The task.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		/// <exception cref="Exception"></exception>
		public async Task<object> CreateTask(TaskCreateDto task)
		{
			var projectEntity = await _projectRepository.FirstOrDefaultAsync(f => f.Id == task.ProjectId);
			if (projectEntity is null)
			{
				throw new Exception(TaskMessageResource.MensajeTareaNoExiste);
			}

			DateExecutionInRange(task.DateExecution, projectEntity.DateInit, projectEntity.DateEnd.Value);

			await _repository.AddAsync(task);
			return new ResponseGenericDto<bool> { Success = true, Message = TaskMessageResource.MensajeTareaCreada };
		}

		/// <summary>
		/// Gets the by task identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		/// <exception cref="Exception"></exception>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<TaskEntity> GetByTaskId(int id)
		{
			var taskEntity = await _repository.FirstOrDefaultAsync(f => f.Id == id);
			if (taskEntity is null)
			{
				throw new Exception(TaskMessageResource.MensajeTareaNoExiste);
			}

			return taskEntity;
		}

		/// <summary>
		/// Tasks the complete.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Task&lt;System.Object&gt;.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<ResponseGenericDto<bool>> TaskComplete(int id)
		{

			var task = await _repository.FirstOrDefaultAsync(f => f.Id == id);

			if (task is null)
			{
				throw new Exception(TaskMessageResource.MensajeTareaNoExiste);
			}

			
			 task.TaskState =  TaskState.Done;
			_repository.Update(task);

			return new ResponseGenericDto<bool> { Success = true, Message = TaskMessageResource.MensajeTareaCompletada };
		}


		/// <summary>
		/// Dates the execution in range.
		/// </summary>
		/// <param name="dateExecution">The date execution.</param>
		/// <param name="dateEnd">The date end.</param>
		/// <param name="dateInit">The date initialize.</param>
		/// <exception cref="Exception"></exception>
		private void DateExecutionInRange(DateTime dateExecution, DateTime? dateEnd, DateTime dateInit)
		{
			var inRange = dateEnd?.Date != null && dateExecution.InRange(dateInit, (DateTime) dateEnd?.Date);

			if (!inRange)
			{
				throw new Exception(TaskMessageResource.MensajeFechaFueraDelRango);
			}

		}
	}
}