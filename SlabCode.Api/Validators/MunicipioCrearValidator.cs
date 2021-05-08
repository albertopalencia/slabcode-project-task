// ***********************************************************************
// Assembly         : PruebaTecnica.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-09-2021
// ***********************************************************************
// <copyright file="MunicipioCrearValidator.cs" company="PruebaTecnica.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace PruebaTecnica.Api.Validators
{
	using FluentValidation;
	using System.Diagnostics.CodeAnalysis;
	using PruebaTecnica.Application.DTO.Municipio;


	/// <summary>
	/// Class MunicipioCrearValidator.
	/// Implements the <see cref="FluentValidation.AbstractValidator{PruebaTecnica.Application.DTO.Municipio.MunicipioCrearDto}" />
	/// </summary>
	/// <seealso cref="FluentValidation.AbstractValidator{PruebaTecnica.Application.DTO.Municipio.MunicipioCrearDto}" />
	[ExcludeFromCodeCoverage]
	public class MunicipioCrearValidator : AbstractValidator<MunicipioCrearDto>
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="MunicipioCrearValidator"/> class.
		/// </summary>
		public MunicipioCrearValidator()
		{

			RuleFor(x => x.DepartamentoId).NotEqual(0).NotNull();

			RuleFor(s => s.Nombre)
				.NotEmpty()
				.NotNull()
				.WithMessage("{PropertyName}  requerido")
				.Length(4, 100);

			RuleFor(s => s.DepartamentoId).NotEqual(0);

			RuleFor(s => s.CodigoDane);

		
		}
	}
}