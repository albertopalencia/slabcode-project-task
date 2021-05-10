// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="SlabCodeContext.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SlabCode.Domain.Entities;

namespace SlabCode.Infrastructure.DataAccess
{
	/// <summary>
	/// Class SlabCodeContext.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class SlabCodeContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SlabCodeContext" /> class.
		/// </summary>
		public SlabCodeContext()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SlabCodeContext" /> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public SlabCodeContext(DbContextOptions<SlabCodeContext> options ) : base(options)
		{
			
		}


		/// <summary>
		/// Gets or sets the proyects.
		/// </summary>
		/// <value>The proyects.</value>
		public virtual DbSet<ProjectEntity> Projects { get; set; }
		/// <summary>
		/// Gets or sets the tasks.
		/// </summary>
		/// <value>The tasks.</value>
		public virtual DbSet<TaskEntity> Tasks { get; set; }
		/// <summary>
		/// Gets or sets the users.
		/// </summary>
		/// <value>The users.</value>
		public virtual DbSet<UserEntity> Users { get; set; }


		/// <summary>
		/// Override this method to further configure the model that was discovered by convention from the entity types
		/// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
		/// and re-used for subsequent instances of your derived context.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
		/// define extension methods on this object that allow you to configure aspects of the model that are specific
		/// to a given database.</param>
		/// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
		/// then this method will not be run.</remarks>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}