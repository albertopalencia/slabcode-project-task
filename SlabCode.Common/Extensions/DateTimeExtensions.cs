// ***********************************************************************
// Assembly         : SlabCode.Common
// Author           : Alberto Palencia
// Created          : 05-10-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-10-2021
// ***********************************************************************
// <copyright file="DateTimeExtensions.cs" company="SlabCode.Common">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace SlabCode.Common.Extensions
{
	/// <summary>
	/// Class DateTimeExtensions.
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Ins the range.
		/// </summary>
		/// <param name="dateToCheck">The date to check.</param>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public static bool InRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
		{
			return dateToCheck >= startDate && dateToCheck <= endDate;
		}
	}

}