﻿// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="ProyectConfiguration.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlabCode.Domain.Entities;

namespace SlabCode.Infrastructure.DataAccess.Configurations
{
	/// <summary>
	/// Class ProyectConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SlabCode.Domain.Entities.ProyectEntity}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SlabCode.Domain.Entities.ProyectEntity}" />
	public class ProyectConfiguration : IEntityTypeConfiguration<ProyectEntity>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<ProyectEntity> builder)
		{
			builder.ToTable("Proyecto");

			builder.HasKey(i => i.Id);
			builder.Property(i => i.Id)
				   .HasColumnName("IdProyecto");

			builder.Property(i => i.ProyectName)
				   .HasColumnName("NombreProyecto")
				   .HasColumnType("nvarchar(150)")
				   .IsRequired()
				   .HasMaxLength(150);

			builder.Property(i => i.Description)
				   .HasColumnName("Descripcion")
				   .HasColumnType("nvarchar(400)")
				   .IsRequired()
				   .HasMaxLength(400);

			builder.Property(i => i.DateInit)
				   .HasColumnName("FechaInicio")
				   .HasColumnType("date");

			builder.Property(i => i.DateEnded)
				   .HasColumnName("FechaFinalizacion")
				   .HasColumnType("date");

			builder.HasMany(t => t.Tasks)
				.WithOne(p => p.Proyect);
		}
	}
}