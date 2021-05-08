// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="Startup.cs" company="SlabCode.Api">
//     Copyright (c)  All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace SlabCode.Api
{
	using Application.Abstract;
	using Filters;
	using FluentValidation.AspNetCore;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.IdentityModel.Tokens;
	using CustomExceptionMiddleware;
	using Application.Implements;
	using Infrastructure.Extensions;
	using System;
	using System.Reflection;
	using System.Text;

	/// <summary>
	/// Class Startup.
	/// </summary>

	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup" /> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add<ValidatorActionFilter>();
			}).AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			});

			ConfigureServicesAdd(services);
		}

		/// <summary>
		/// Configures the service add.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServicesAdd(IServiceCollection services)
		{
			services.AddOptions(Configuration);

			services.AddDbContexts(Configuration);

			AddApplicationService(services);

			services.AddServicesRepositories();

			services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

			AddAuthentication(services);

			services.AddCors(o => o.AddPolicy("AllowClientApp", builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));

			services.AddResponseCaching();
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("swagger/v1/swagger.json", "V1");
				options.RoutePrefix = string.Empty;
				options.DefaultModelsExpandDepth(-1);
			});

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseResponseCaching();

			app.Use(async (context, next) =>
			{
				context.Response.GetTypedHeaders().CacheControl =
					new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
					{
						Public = true,
						MaxAge = TimeSpan.FromSeconds(5)
					};
				context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
					new[] { "Accept-Encoding" };

				await next();
			});

			app.UseMiddleware<ExceptionMiddleware>();

			app.UseCors("AllowClientApp");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Adds the application service.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public void AddApplicationService(IServiceCollection services)
		{
			services.AddSingleton<IPasswordService, PasswordService>();
			services.AddTransient<IUserService, UserService>();
		}

		/// <summary>
		/// Adds the authentication.
		/// </summary>
		/// <param name="services">The services.</param>
		public void AddAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration[Common.Enumerations.Authentication.Editor.Name],
					ValidAudience = Configuration[Common.Enumerations.Authentication.Audience.Name],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[Common.Enumerations.Authentication.SecretyKey.Name]))
				};
			});
		}
	}
}