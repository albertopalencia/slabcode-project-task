// ***********************************************************************
// Assembly         : SlabCode.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="IDapperRepository.cs" company="SlabCode.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlabCode.Infrastructure.Interfaces
{
	/// <summary>
	/// Interface IDapperRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IDapperRepository<T> where T : class
	{
		/// <summary>
		/// Executes the query select asynchronous.
		/// </summary>
		/// <param name="cnx">The CNX.</param>
		/// <param name="query">The query.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		Task<IEnumerable<T>> ExecuteQuerySelectAsync(string cnx, string query, object filter = null);

		/// <summary>
		/// Executes the first or default asynchronous.
		/// </summary>
		/// <param name="cnx">The CNX.</param>
		/// <param name="query">The query.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		Task<T> ExecuteFirstOrDefaultAsync(string cnx, string query, object filter = null);

		/// <summary>
		/// Executes the store procedure asynchronous.
		/// </summary>
		/// <param name="cnx">The CNX.</param>
		/// <param name="storeProcedure">The store procedure.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		Task<IEnumerable<T>> ExecuteStoreProcedureAsync(string cnx, string storeProcedure, object filter = null);

		/// <summary>
		/// Executes the query scalar asynchronous.
		/// </summary>
		/// <param name="cnx">The CNX.</param>
		/// <param name="query">The query.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>Task&lt;System.Int32&gt;.</returns>
		Task<int> ExecuteQueryScalarAsync(string cnx, string query, object filter = null);
	}
}