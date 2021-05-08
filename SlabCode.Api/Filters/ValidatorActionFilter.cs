// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="ValidatorActionFilter.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SlabCode.Domain.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SlabCode.Api.Filters
{ 

	/// <summary>
	/// Class ValidatorActionFilter.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter" />
	public class ValidatorActionFilter : IAsyncResultFilter
	{
		/// <summary>
		/// on result execution as an asynchronous operation.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext" />.</param>
		/// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate" />. Invoked to execute the next result filter or the result itself.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that on completion indicates the filter has executed.</returns>
		/// <exception cref="ValidationException"></exception>
		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);

				var modelStateDictionaryArray = context.ModelState
					.Where(w => w.Value.Errors.Count > 0)
					.Select(s => (s.Key, s.Value.Errors.Select(x => x.ErrorMessage)))
					.ToArray();

				var errorList = new List<MessageErrorDto>();

				foreach (var (key, enumerable) in modelStateDictionaryArray)
				{
					errorList.AddRange(enumerable.Select(i => new MessageErrorDto { Property = key, Message = i }));
				}

				if (errorList.Any())
				{
					throw new ValidationException((IEnumerable<FluentValidation.Results.ValidationFailure>)errorList.AsEnumerable());
				}
			}

			await next();
		}
	}
}