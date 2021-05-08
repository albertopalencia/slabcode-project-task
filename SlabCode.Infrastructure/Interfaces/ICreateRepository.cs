// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="ICreateRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SlabCode.Infrastructure.Interfaces
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface ICreateRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ICreateRepository<in T> where T : class
	{
		/// <summary>
		/// Adds the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Add(T t);

		/// <summary>
		/// Adds the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Add(IEnumerable<T> t);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>Task.</returns>
		Task AddAsync(T t);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>Task.</returns>
		Task AddAsync(IEnumerable<T> t);
	}
}