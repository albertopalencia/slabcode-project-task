// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="MailConfigDto.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SlabCode.Application.DTO.Mail
{
	/// <summary>
	/// Class MailConfigDto.
	/// </summary>
	public class MailConfigDto
	{
		/// <summary>
		/// Gets or sets the subject.
		/// </summary>
		/// <value>The subject.</value>
		public string Subject { get; set; }
		/// <summary>
		/// Gets or sets the body.
		/// </summary>
		/// <value>The body.</value>
		public string Body { get; set; }
		/// <summary>
		/// Gets or sets from.
		/// </summary>
		/// <value>From.</value>
		public string From { get; set; }
		/// <summary>
		/// Gets or sets to.
		/// </summary>
		/// <value>To.</value>
		public string To { get; set; }
		/// <summary>
		/// Gets or sets the host.
		/// </summary>
		/// <value>The host.</value>
		public string Host { get; set; }
		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>The user.</value>
		public string User { get; set; }
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; set; }
		/// <summary>
		/// Gets or sets the port.
		/// </summary>
		/// <value>The port.</value>
		public int Port { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether [enable SSL].
		/// </summary>
		/// <value><c>true</c> if [enable SSL]; otherwise, <c>false</c>.</value>
		public bool EnableSsl { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="MailConfigDto" /> to <see cref="MailMessage" />.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator MailMessage(MailConfigDto mailConfig)
		{
			var from = new MailAddress(mailConfig.From);
			var to = new MailAddress(mailConfig.To);
			var message = new MailMessage(from, to)
			{
				Subject = mailConfig.Subject, Body = mailConfig.Body, IsBodyHtml = true
			};
			return message;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="MailConfigDto" /> to <see cref="SendGridMessage" />.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SendGridMessage(MailConfigDto mailConfig)
		{
			var message = new SendGridMessage();
			var from = new EmailAddress(mailConfig.From);
			message.SetFrom(from);
			var to = new EmailAddress(mailConfig.To);
			message.AddTo(to);
			message.SetSubject(mailConfig.Subject);
			message.AddContent(MimeType.Html, mailConfig.Body);
			return message;
		}
	}
}