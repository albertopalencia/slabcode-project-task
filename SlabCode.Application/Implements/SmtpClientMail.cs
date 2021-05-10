// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="SmtpClientMail.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using SlabCode.Application.Abstract;
using SlabCode.Domain.DTO.Mail;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SlabCode.Application.DTO.Mail;

namespace SlabCode.Application.Implements
{
	/// <summary>
	/// Class SmtpClientMail.
	/// Implements the <see cref="SlabCode.Application.Abstract.ITypeMail" />
	/// </summary>
	/// <seealso cref="SlabCode.Application.Abstract.ITypeMail" />
	public class SmtpClientMail : ITypeMail
	{
		public MailResultDto SendMail(MailConfigDto mailConfig)
		{
			var client = new SmtpClient(mailConfig.Host)
			{
				Credentials = new NetworkCredential(mailConfig.User, mailConfig.Password)
			};
			client.SendCompleted += Mail_SendCompleted;
			client.Send(mailConfig);
			return new MailResultDto();
		}

		private void Mail_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			//
		}

		public async Task<MailResultDto> SendMailAsync(MailConfigDto mailConfig)
		{
			var client = new SmtpClient(mailConfig.Host, mailConfig.Port)
			{
				Credentials = new NetworkCredential(mailConfig.User, mailConfig.Password)
			};
			client.SendCompleted += Mail_SendCompleted;
			client.EnableSsl = mailConfig.EnableSsl;
			await client.SendMailAsync(mailConfig);
			return new MailResultDto();
		}
	}
}