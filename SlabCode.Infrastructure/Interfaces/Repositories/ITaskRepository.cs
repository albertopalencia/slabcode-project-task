// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="ITaskRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Domain.Entities;

namespace SlabCode.Infrastructure.Interfaces.Repositories
{
	/// <summary>
	/// Interface ITaskRepository
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.ICreateRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.IUpdateRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.IRemoveRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// </summary>
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.ICreateRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.IUpdateRepository{SlabCode.Domain.Entities.TaskEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.IRemoveRepository{SlabCode.Domain.Entities.TaskEntity}" />
	public interface ITaskRepository: ICreateRepository<TaskEntity>, IUpdateRepository<TaskEntity>, IRemoveRepository<TaskEntity>
	{
		
	}
}