// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="ProjectRepository.cs" company="SlabCode.Infrastructure">
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
	/// Class ProjectRepository.
	/// Implements the <see cref="SlabCode.Infrastructure.Repository.GenericRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.Repositories.IProjectRepository" />
	/// </summary>
	/// <seealso cref="SlabCode.Infrastructure.Repository.GenericRepository{SlabCode.Domain.Entities.ProjectEntity}" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.Repositories.IProjectRepository" />
	public class ProjectRepository : GenericRepository<ProjectEntity>, IProjectRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public ProjectRepository(SlabCodeContext context) : base(context)
		{
		}
	}
}