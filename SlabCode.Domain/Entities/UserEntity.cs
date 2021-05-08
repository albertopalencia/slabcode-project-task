// ***********************************************************************
// Assembly         : Slabcode.Domain
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-07-2021
// ***********************************************************************
// <copyright file="UserEntity.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SlabCode.Common.Enumerations;

namespace SlabCode.Domain.Entities
{
    /// <summary>
    /// Class UserEntity.
    /// Implements the <see cref="SlabCode.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="SlabCode.Domain.Entities.Entity" />
    public class UserEntity : Entity
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>The active.</value>
        public UserState Active { get; set; }
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public RoleType Role { get; set; }
    }
}