
// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="RolesAttribute .cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Api.Attributes
{
	using Microsoft.AspNetCore.Authorization;
	using System;

	/// <summary>
	/// Class RolesAttribute_.
	/// Implements the <see cref="Microsoft.AspNetCore.Authorization.AuthorizeAttribute" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Authorization.AuthorizeAttribute" />
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	public class RolesAttribute : AuthorizeAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RolesAttribute" /> class.
		/// </summary>
		/// <param name="roles">The roles.</param>
		public RolesAttribute(params string[] roles)
		{
			Roles = string.Join(",", roles);
		}
	}
}