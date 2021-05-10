// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="IMailService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using SlabCode.Application.DTO.Mail;
using SlabCode.Domain.DTO.Mail;

namespace SlabCode.Application.Abstract
{
	/// <summary>
	/// Interface IMailService
	/// </summary>
	public interface IMailService
	{
		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>MailResultDto.</returns>
		MailResultDto SendMail(MailConfigDto mailConfig);

		/// <summary>
		/// Sends the mail asynchronous.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>Task&lt;MailResultDto&gt;.</returns>
		Task<MailResultDto> SendMailAsync(MailConfigDto mailConfig);
	}
}