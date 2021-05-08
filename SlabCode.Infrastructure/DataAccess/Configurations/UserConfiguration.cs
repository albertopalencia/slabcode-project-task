// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="UserConfiguration.cs" company="SlabCode.Infrastructure">
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
	/// Class UserConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SlabCode.Domain.Entities.UserEntity}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SlabCode.Domain.Entities.UserEntity}" />
	public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.ToTable("Usuario");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				   .HasColumnName("IdUsuario");

			builder.Property(e => e.UserName)
				   .HasColumnName("Usuario")
				   .IsRequired()
				   .HasMaxLength(50)
				   .IsUnicode(false);

			builder.Property(e => e.Password)
				   .HasColumnName("Contrasena")
				   .IsRequired()
				   .HasMaxLength(200)
				   .IsUnicode(false);

			builder.Property(i => i.Email)
				   .HasColumnName("Email")
				   .HasColumnType("nvarchar(90)")
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(e => e.Active)
				   .HasColumnName("Activo")
				   .IsRequired()
				   .HasConversion(
									x => x.Id,
									x => Enumeration.FromValue<UserState>(x)
								 );

			builder.Property(e => e.Role)
				   .HasColumnName("Rol")
				   .IsRequired()
				   .HasConversion(
									r => r.Id,
									r => Enumeration.FromValue<RoleType>(r)
								 );
		}
	}
}