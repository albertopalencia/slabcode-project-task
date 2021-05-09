// ***********************************************************************
// Assembly         : 
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="ExceptionMiddleware.cs" company="AlbertPalencia">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SlabCode.Api.CustomExceptionMiddleware
{
	/// <summary>
	/// Class ExceptionMiddleware.
	/// </summary>
	public class ExceptionMiddleware
	{
		/// <summary>
		/// The next
		/// </summary>
		private readonly RequestDelegate _next;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
		/// </summary>
		/// <param name="next">The next.</param>
		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		/// <summary>
		/// invoke as an asynchronous operation.
		/// </summary>
		/// <param name="httpContext">The HTTP context.</param>
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		/// <summary>
		/// Handles the exception asynchronous.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="exception">The exception.</param>
		/// <returns>Task.</returns>
		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			
			await context.Response.WriteAsync(new 
			{
				context.Response.StatusCode,
				exception.Message
			}.ToString() ?? string.Empty);
		}
	}
}