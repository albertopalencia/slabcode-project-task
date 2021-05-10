// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="TaskConfiguration.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlabCode.Common.Enumerations;
using SlabCode.Domain.Entities;

namespace SlabCode.Infrastructure.DataAccess.Configurations
{
	/// <summary>
	/// Class TaskConfiguration.
	/// Implements the <see cref="TaskEntity" />
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SlabCode.Domain.Entities.TaskEntity}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SlabCode.Domain.Entities.TaskEntity}" />
	/// <seealso cref="TaskEntity" />
	public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<TaskEntity> builder)
		{
			builder.ToTable("Tarea");

			builder.HasKey(i => i.Id);
			builder.Property(i => i.Id)
				   .HasColumnName("IdTarea");

			builder.Property(i => i.ProjectId)
				  .HasColumnName("IdProyecto");

			builder.Property(i => i.TaskName)
				.HasColumnName("Nombre")
				.HasColumnType("nvarchar(350)")
				.IsRequired()
				.HasMaxLength(350);

			builder.Property(e => e.TaskState)
				.HasColumnName("Estado")
				.IsRequired()
				.HasConversion(
					t => t.Id,
					t => Enumeration.FromValue<TaskState>(t));

			builder.Property(i => i.Description)
					   .HasColumnName("Descripcion")
					   .HasColumnType("nvarchar(600)")
					   .IsRequired()
					   .HasMaxLength(600);

			builder.Property(i => i.DateExecution)
				   .HasColumnName("FechaEjecucion")
				   .HasColumnType("date");
		}
	}
}