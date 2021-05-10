// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="SendGridMail.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO.Mail;
using System.Threading.Tasks;
using SendGrid;
using SlabCode.Application.DTO.Mail;

namespace SlabCode.Application.Implements
{
	/// <summary>
	/// Class SendGridMail.
	/// Implements the <see cref="SlabCode.Application.Abstract.ITypeMail" />
	/// </summary>
	/// <seealso cref="SlabCode.Application.Abstract.ITypeMail" />
	public class SendGridMail : ITypeMail
	{
		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>MailResultDto.</returns>
		public MailResultDto SendMail(MailConfigDto mailConfig)
		{
			return SendMailAsync(mailConfig).Result;
		}

		/// <summary>
		/// send mail as an asynchronous operation.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>Task&lt;MailResultDto&gt;.</returns>
		public async Task<MailResultDto> SendMailAsync(MailConfigDto mailConfig)
		{
			var apiKey = mailConfig.Password;
			var client = new SendGridClient(apiKey);
			return await client.SendEmailAsync(mailConfig);
		}
	}
}