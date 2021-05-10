// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="ProjectService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.EntityFrameworkCore;
using SlabCode.Application.Abstract;
using SlabCode.Common.Enumerations;
using SlabCode.Common.Resources;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.Project;
using SlabCode.Domain.Entities;
using SlabCode.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlabCode.Application.Implements
{
	/// <summary>
	/// Class ProjectService.
	/// Implements the <see cref="SlabCode.Application.Abstract.IProjectService" />
	/// </summary>
	/// <seealso cref="SlabCode.Application.Abstract.IProjectService" />
	public class ProjectService : IProjectService
	{
		/// <summary>
		/// The repository
		/// </summary>
		private readonly IProjectRepository _repository;

		/// <summary>
		/// The user service
		/// </summary>
		private readonly IUserService _userService;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectService" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="userService">The user service.</param>
		public ProjectService(IProjectRepository repository, IUserService userService)
		{
			_repository = repository;
			_userService = userService;
		}

		/// <summary>
		/// Gets the by project identifier.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;ProjectIdResultDto&gt;&gt;.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<ResponseGenericDto<ProjectIdResultDto>> GetByProjectId(int projectId)
		{
			var projectExits = await _repository.FirstOrDefaultAsync(p => p.Id == projectId);
			return new ResponseGenericDto<ProjectIdResultDto>
			{
				Success = true,
				Result = projectExits
			};
		}

		/// <summary>
		/// Projectses the specified page.
		/// </summary>
		/// <param name="take">The take.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;ProjectListDto&gt;&gt;.</returns>
		public async Task<ResponseGenericDto<List<ProjectListDto>>> Projects(int take)
		{
			var projects = await _repository.GetAllAsync(take: take);
			var projectList = projects.Select<ProjectEntity, ProjectListDto>(s => s).ToList();
			return new ResponseGenericDto<List<ProjectListDto>> { Success = true, Result = projectList };
		}

		/// <summary>
		/// Creates the project.
		/// </summary>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		public async Task<ResponseGenericDto<bool>> CreateProject(ProjectCreateDto project)
		{
			await _repository.AddAsync(project);
			return new ResponseGenericDto<bool> { Success = true, Message = ProjectMessageResource.MensajeProyectoCreado };
		}

		/// <summary>
		/// Updates the project.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <param name="project">The project.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<ResponseGenericDto<bool>> UpdateProject(int projectId, ProjectUpdateDto project)
		{
			var projectUpdate = await _repository.FirstOrDefaultAsync(f => f.Id == projectId);
			if (projectUpdate is null)
			{
				throw new Exception(ProjectMessageResource.MensajeProyectoNoExiste);
			}

			var hasTask = projectUpdate.Tasks.Count(s => s.DateExecution > project.DateEnd);
			if (hasTask > decimal.Zero)
			{
				throw new Exception(ProjectMessageResource.MensajeFechaEjecucion);
			}

			projectUpdate.Description = project.Description;
			projectUpdate.ProjectName = project.ProjectName;
			projectUpdate.DateEnd = project.DateEnd;

			_repository.Update(projectUpdate);

			return new ResponseGenericDto<bool>
				{Success = true, Message = ProjectMessageResource.MensajeProyectoActualizado};
		}

		/// <summary>
		/// Removes the project.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		public async Task<ResponseGenericDto<bool>> RemoveProject(int projectId)
		{
			var projects = await FindProjectById(projectId);

			var projectEntities = projects.ToList();
			_repository.Remove(projectEntities);

			return new ResponseGenericDto<bool>
			{
				Success = true,
				Message = ProjectMessageResource.MensajeEliminarProyecto.
					Replace("{0}", projectEntities.Count.ToString())
			};
		}

		/// <summary>
		/// Projects the complete.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;System.Boolean&gt;&gt;.</returns>
		public async Task<ResponseGenericDto<bool>> ProjectComplete(int projectId)
		{
			var result = await ProjectCompleteValidation(projectId);
			var response = new ResponseGenericDto<bool> { Success = false, Message = result.Message };
			if (!result.Success) return response;

			result.Result.State = ProjectState.Done;
			_repository.Update(result.Result);
			await _userService.NotifierUserAdministrador(string.Join(" ", result.Message, result.Result.ProjectName), ProjectMessageResource.MensajeProyectoFinalizadoTitulo);
			response.Success = true;
			return response;
		}

		/// <summary>
		/// Projects the complete validation.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;ResponseGenericDto&lt;ProjectEntity&gt;&gt;.</returns>
		private async Task<ResponseGenericDto<ProjectEntity>> ProjectCompleteValidation(int projectId)
		{
			var project = await _repository.FirstOrDefaultAsync(f => f.Id == projectId &&
																 f.State == ProjectState.InProgress,
				include: source => source.Include(p => p.Tasks));

			if (project is null)
			{
				throw new Exception(ProjectMessageResource.MensajeProyectFinalizadoNoEncontrado);
			}

			var equal = project.Tasks.Count == project.Tasks.Count(c => c?.TaskState == TaskState.Done);

			var responseGeneric = new ResponseGenericDto<ProjectEntity>
			{
				Message = !equal
					? ProjectMessageResource.MensajeTareasPorRealizar
					: ProjectMessageResource.MensajeProyectoFinalizado,
				Success = equal,
				Result = equal ? project : null
			};

			return responseGeneric;
		}

		/// <summary>
		/// Finds the project by identifier.
		/// </summary>
		/// <param name="projectId">The project identifier.</param>
		/// <returns>Task&lt;IEnumerable&lt;ProjectEntity&gt;&gt;.</returns>
		private async Task<IEnumerable<ProjectEntity>> FindProjectById(int projectId)
		{
			var projects = await _repository.GetAllAsync(s => s.Id == projectId,
				include: source => source.Include(p => p.Tasks));
			return projects;
		}
	}
}