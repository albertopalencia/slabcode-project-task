// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IUpdateRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Infrastructure.Interfaces
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface IUpdateRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IUpdateRepository<in T> where T : class
	{
		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Update(T t);

		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Update(IEnumerable<T> t);
	}
}