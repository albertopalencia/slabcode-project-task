// ***********************************************************************
// Assembly         : SlabCode.Domain
// Author           : Alberto Palencia
// Created          : 05-06-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-06-2021
// ***********************************************************************
// <copyright file="TaskEntity.cs" company="SlabCode.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using SlabCode.Common.Enumerations;

namespace SlabCode.Domain.Entities
{
    /// <summary>
    /// Class TaskEntity.
    /// Implements the <see cref="SlabCode.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="SlabCode.Domain.Entities.Entity" />
    public class TaskEntity : Entity
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>The name of the task.</value>
        public string TaskName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the date execution.
        /// </summary>
        /// <value>The date execution.</value>
        public DateTime DateExecution { get; set; }
        /// <summary>
        /// Gets or sets the identifier proyect.
        /// </summary>
        /// <value>The identifier proyect.</value>
        public int ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the state of the task.
        /// </summary>
        /// <value>The state of the task.</value>
        public TaskState TaskState { get; set; }
        /// <summary>
        /// Gets or sets the proyect.
        /// </summary>
        /// <value>The proyect.</value>
        public ProjectEntity Project { get; set; }
    }
}