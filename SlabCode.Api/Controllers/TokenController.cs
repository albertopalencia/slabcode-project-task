// ***********************************************************************
// Assembly         : SlabCode.Api
// Author           : Alberto Palencia
// Created          : 05-07-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-08-2021
// ***********************************************************************
// <copyright file="TokenController.cs" company="SlabCode.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO.User;
using SlabCode.Infrastructure.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SlabCode.Api.Controllers
{
	/// <summary>
	/// Class TokenController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		/// <summary>
		/// The user service
		/// </summary>
		private readonly IUserService _userService;

		/// <summary>
		/// The authentication option
		/// </summary>
		private readonly AuthenticationOption _authenticationOption;

		/// <summary>
		/// Initializes a new instance of the <see cref="TokenController" /> class.
		/// </summary>
		/// <param name="userService">The user service.</param>
		/// <param name="authenticationOption">The authentication option.</param>
		public TokenController(IUserService userService, IOptions<AuthenticationOption> authenticationOption)
		{
			_userService = userService;
			_authenticationOption = authenticationOption.Value;
		}

		/// <summary>
		/// Authentications the specified user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(nameof(Authentication))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserResponseDto))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Authentication(UserLoginDto user)
		{
			var result = await _userService.ValidateUser(user);
			return Ok(GenerateToken(result));
		}

		/// <summary>
		/// Generates the token.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>System.String.</returns>
		private string GenerateToken(UserResponseDto user)
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOption.SecretKey));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var header = new JwtHeader(signingCredentials);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim("User", user.UserName),
				new Claim(ClaimTypes.Role, user.RolType),
			};

			var payload = new JwtPayload
			(
				_authenticationOption.Issuer,
				_authenticationOption.Audience,
				claims,
				DateTime.Now,
				DateTime.UtcNow.AddMinutes(_authenticationOption.Minutes)
			);

			var token = new JwtSecurityToken(header, payload);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}