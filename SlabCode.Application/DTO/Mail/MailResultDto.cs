// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-09-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-09-2021
// ***********************************************************************
// <copyright file="MailResultDto.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Common.Enumerations;

namespace SlabCode.Domain.DTO.Mail
{
    /// <summary>
    /// Class MailResultDto.
    /// </summary>
    public class MailResultDto
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public StatusType Status { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MailResultDto"/> is error.
        /// </summary>
        /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
        public bool Error { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SendGrid.Response"/> to <see cref="MailResultDto"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MailResultDto(SendGrid.Response response)
        {
            return new ()
            {
                Status = response.IsSuccessStatusCode ? StatusType.Success : StatusType.Fail,
                Error = response.IsSuccessStatusCode,
                Message = response.StatusCode.ToString()
            };
        }
    }
}