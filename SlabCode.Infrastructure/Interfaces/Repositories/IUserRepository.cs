// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="IUserRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using SlabCode.Domain.Entities;

namespace SlabCode.Infrastructure.Interfaces.Repositories
{
	/// <summary>
	/// Interface IUserRepository
	/// </summary>
	public interface IUserRepository : IReadRepository<UserEntity>, ICreateRepository<UserEntity>, IUpdateRepository<UserEntity>
	{
		
	}
}