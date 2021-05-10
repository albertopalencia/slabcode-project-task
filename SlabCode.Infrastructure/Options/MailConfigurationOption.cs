// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="MailConfigurationOption.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace SlabCode.Infrastructure.Options
{
	/// <summary>
	/// Class MailConfigurationOption.
	/// </summary>
	public class MailConfigurationOption
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
		public string Username { get; set; }

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
	}
}