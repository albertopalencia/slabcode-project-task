// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="IProjectRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Domain.Entities;

namespace SlabCode.Infrastructure.Interfaces.Repositories
{
	/// <summary>
	/// Interface IProjectRepository
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.IReadRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.ICreateRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.IUpdateRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.IRemoveRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// </summary>
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.IReadRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.ICreateRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.IUpdateRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.IRemoveRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	public interface IProjectRepository : IReadRepository<ProjectEntity>,ICreateRepository<ProjectEntity>, IUpdateRepository<ProjectEntity>, IRemoveRepository<ProjectEntity>
	{
		
	}
}