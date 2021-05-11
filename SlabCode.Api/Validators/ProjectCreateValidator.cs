// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-10-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="ProjectCreateValidator.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using SlabCode.Domain.DTO.Project;
using System;

namespace SlabCode.Api.Validators
{
	/// <summary>
	/// Class ProjectCreateValidator.
	/// Implements the <see />
	/// </summary>
	/// <seealso />
	public class ProjectCreateValidator : AbstractValidator<ProjectCreateDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectCreateValidator"/> class.
		/// </summary>
		public ProjectCreateValidator()
		{
			RuleFor(n => n.ProjectName).NotNull().NotEmpty()
				.WithMessage("campo obligatorio");

			RuleFor(n => n.Description).NotNull().NotEmpty()
				.WithMessage("campo obligatorio");

			RuleFor(x => x.DateInit).LessThan(DateTime.Now)
				.WithMessage("Debe ser posterior o igual al día presente");

			RuleFor(x => x.DateEnd)
				.GreaterThanOrEqualTo(x => x.DateInit)
				.WithMessage("Debe ser posterior o igual a la fecha de inicio");
		}
	}
}