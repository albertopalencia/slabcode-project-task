// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="ServiceCollectionExtension.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Common.Enumerations;
using SlabCode.Infrastructure.DataAccess;
using SlabCode.Infrastructure.Interfaces.Repositories;
using SlabCode.Infrastructure.Repository;

namespace SlabCode.Infrastructure.Extensions
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.OpenApi.Models;
	using Options;
	using System;
	using System.IO;

	/// <summary>
	/// Class ServiceCollectionExtension.
	/// </summary>

	public static class ServiceCollectionExtension
	{
		/// <summary>
		/// Adds the database contexts.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration[ConnectionString.SlabCode.Name];

			services.AddDbContext<SlabCodeContext>(options =>
				 options.UseSqlServer(connectionString,
				   sqlOptions =>
				   {
					   sqlOptions.EnableRetryOnFailure(
					   10,
					   TimeSpan.FromSeconds(30),
					   null);
				   })
		   );

			return services;
		}

		/// <summary>
		/// Adds the options.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<PasswordOption>(options => configuration.GetSection("PasswordOption").Bind(options));
			services.Configure<AuthenticationOption>(options => configuration.GetSection("Authentication").Bind(options));
			return services;
		}

		/// <summary>
		/// Adds the services.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddServicesRepositories(this IServiceCollection services)
		{
		 
			services.AddTransient<IUserRepository, UserRepository>();

			return services;
		}

		/// <summary>
		/// Adds the swagger.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="xmlFileName">Name of the XML file.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
		{
			services.AddSwaggerGen(doc =>
			{
				doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba Tecnica SlabCode - Proyectos -> Tareas ", Version = "v1" });

				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
				doc.IncludeXmlComments(xmlPath);

				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "Authorization ",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				};
				doc.AddSecurityDefinition("Bearer", securitySchema);

				var securityRequirement = new OpenApiSecurityRequirement
				{
					{ securitySchema, new[] { "Bearer" } }
				};
				doc.AddSecurityRequirement(securityRequirement);
			});

			return services;
		}
	}
}