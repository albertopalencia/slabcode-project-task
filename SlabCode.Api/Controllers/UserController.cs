// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-08-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="UserController.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO;
using SlabCode.Domain.DTO.User;
using System.Net;
using System.Threading.Tasks;

namespace SlabCode.Api.Controllers
{
	/// <summary>
	/// Class UserController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Authorize(Roles = "Administrador")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		/// <summary>
		/// The user service
		/// </summary>
		private readonly IUserService _userService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserController" /> class.
		/// </summary>
		/// <param name="userService">The user service.</param>
		public UserController(IUserService userService)
		{
			_userService = userService;
		}


		/// <summary>
		/// Creates the specified user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost ]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CreateUser(UserCreateDto user)
		{
			var userCreated = await _userService.Create(user);
			return CreatedAtAction("CreateUser", userCreated);
		}

		/// <summary>
		/// Updates the password.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[AllowAnonymous]
		[HttpPut(nameof(UpdatePassword))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserResponseDto))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> UpdatePassword(UserUpdatePasswordDto user)
		{
			var responseUpdated = await _userService.UpdatePassword(user);
			return Ok(responseUpdated);
		}

		/// <summary>
		/// Users the inactivate.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut(nameof(UserInactivate))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> UserInactivate([FromBody] UserInactivateDto user)
		{
			var resultInactivate = await _userService.UserInactivate(user);
			return Ok(resultInactivate);
		}
	}
}