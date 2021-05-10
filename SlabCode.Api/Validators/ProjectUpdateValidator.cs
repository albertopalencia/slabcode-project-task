// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-10-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="ProjectUpdateValidator.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using SlabCode.Domain.DTO.Project;

namespace SlabCode.Api.Validators
{
	/// <summary>
	/// Class ProjectUpdateValidator.
	/// Implements the <see>
	///     <cref>FluentValidation.AbstractValidator{SlabCode.Domain.DTO.Project.ProjectUpdateDto}</cref>
	/// </see>
	/// </summary>
	/// <seealso>
	///     <cref>FluentValidation.AbstractValidator{SlabCode.Domain.DTO.Project.ProjectUpdateDto}</cref>
	/// </seealso>
	public class ProjectUpdateValidator : AbstractValidator<ProjectUpdateDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectUpdateValidator"/> class.
		/// </summary>
		public ProjectUpdateValidator()
		{
			RuleFor(n => n.ProjectName)
				.NotNull()
				.NotEmpty()
				.WithMessage("el nombre del proyecto es obligatorio");

			RuleFor(n => n.Description)
				.NotNull()
				.NotEmpty()
				.WithMessage("la descripcion es obligatorio");

			RuleFor(n => n.DateEnd)
				.NotNull()
				.NotEmpty()
				.WithMessage("la fecha de finalizacion es obligatoria");
		}
	}
}