using System;
using SlabCode.Application.Abstract;
using SlabCode.Application.Implements;
using SlabCode.Common.Enumerations;

namespace SlabCode.Application
{
	public class MailFabric
	{
		internal static ITypeMail Create(MailType type)
		{
			return type switch
			{
				MailType.Smtp => new SmtpClientMail(),
				MailType.SendGrid => new SendGridMail(),
				_ => throw new ArgumentException("Type not defined", "type")
			};
		}
	}
}