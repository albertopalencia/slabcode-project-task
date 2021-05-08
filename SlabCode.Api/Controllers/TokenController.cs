// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="TokenController.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.User;
using System.Net;
using System.Threading.Tasks;

namespace SlabCode.Api.Controllers
{
	/// <summary>
	/// Class TokenController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		/// <summary>
		/// The user service
		/// </summary>
		private readonly IUserService _userService;

		/// <summary>
		/// Initializes a new instance of the <see cref="TokenController"/> class.
		/// </summary>
		/// <param name="userService">The user service.</param>
		public TokenController(IUserService userService)
		{
			_userService = userService;
		}

		/// <summary>
		/// Authentications the specified user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(nameof(Authentication))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<UserResponseDto>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Authentication(UserLoginDto user)
		{
			var result = await _userService.ValidateUser(user);
			return Ok(result);
		}
	}
}