// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-10-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="UserCreateValidator.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using SlabCode.Domain.DTO.User;

namespace SlabCode.Api.Validators
{
	/// <summary>
	/// Class UserCreateValidator.
	/// Implements the <see>
	///     <cref>FluentValidation.AbstractValidator{SlabCode.Domain.DTO.User.UserCreateDto}</cref>
	/// </see>
	/// </summary>
	/// <seealso>
	///     <cref>FluentValidation.AbstractValidator{SlabCode.Domain.DTO.User.UserCreateDto}</cref>
	/// </seealso>
	public class UserCreateValidator : AbstractValidator<UserCreateDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserCreateValidator" /> class.
		/// </summary>
		public UserCreateValidator()
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Nombre de usuario es obligatorio");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Correro es incorrecto");
		}
	}
}