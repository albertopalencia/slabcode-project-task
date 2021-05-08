// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="UserRepository.cs" company="SlabCode.Infrastructure">
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
	/// Class UserRepository.
	/// Implements the <see cref="UserEntity" />
	/// Implements the <see cref="SlabCode.Infrastructure.Interfaces.Repositories.IUserRepository" />
	/// </summary>
	/// <seealso cref="UserEntity" />
	/// <seealso cref="SlabCode.Infrastructure.Interfaces.Repositories.IUserRepository" />
	public class UserRepository : GenericRepository<UserEntity>, IUserRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UserRepository(SlabCodeContext context) : base(context)
		{
		}
	}
}