// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="TaskRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Domain.Entities;
using SlabCode.Infrastructure.DataAccess;
using SlabCode.Infrastructure.Interfaces.Repositories;

namespace SlabCode.Infrastructure.Repository
{
	/// <summary>
	/// Class TaskRepository.
	/// Implements the <see cref="SlabCode.Infrastructure.Repository.GenericRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.Repositories.ITaskRepository" />
	/// </summary>
	/// <seealso cref="SlabCode.Infrastructure.Repository.GenericRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.Repositories.ITaskRepository" />
	public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TaskRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TaskRepository(SlabCodeContext context) : base(context)
		{
		}
	}
}