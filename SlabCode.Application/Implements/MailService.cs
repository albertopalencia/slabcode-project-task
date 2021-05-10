// ***********************************************************************
// Assembly         : SlabCode.Application
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="MailService.cs" company="SlabCode.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using SlabCode.Application.DTO.Mail;

namespace SlabCode.Application.Implements
{
	using Microsoft.Extensions.Configuration;
	using SlabCode.Application.Abstract;
	using SlabCode.Common.Enumerations;
	using SlabCode.Domain.DTO.Mail;
	using System.Threading.Tasks;
	using static System.Enum;

	/// <summary>
	/// Class MailService.
	/// Implements the <see cref="SlabCode.Application.Abstract.IMailService" />
	/// </summary>
	/// <seealso cref="SlabCode.Application.Abstract.IMailService" />
	public class MailService : IMailService
	{
		/// <summary>
		/// The mail service
		/// </summary>
		private readonly ITypeMail _mailService;

		/// <summary>
		/// Initializes a new instance of the <see cref="MailService"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public MailService(IConfiguration configuration)
		{
			var section = configuration.GetSection("MailType");
			if (section.Value != null)
			{
				TryParse(section.Value, out MailType mailType);
				_mailService = MailFabric.Create(mailType);
			}
			_mailService = MailFabric.Create(MailType.Smtp);
		}

		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>MailResultDto.</returns>
		public MailResultDto SendMail(MailConfigDto mailConfig)
		{
			return _mailService.SendMail(mailConfig);
		}

		/// <summary>
		/// send mail as an asynchronous operation.
		/// </summary>
		/// <param name="mailConfig">The mail configuration.</param>
		/// <returns>Task&lt;MailResultDto&gt;.</returns>
		public async Task<MailResultDto> SendMailAsync(MailConfigDto mailConfig)
		{
			return await _mailService.SendMailAsync(mailConfig);
		}
	}
}