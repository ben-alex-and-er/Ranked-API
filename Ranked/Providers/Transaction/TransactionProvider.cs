using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace Ranked.Providers.Transaction
{
	using Interfaces;


	/// <summary>
	/// Provider for creating transactions
	/// </summary>
	/// <typeparam name="T">Type of DbContext</typeparam>
	public class TransactionProvider<T> : ITransactionProvider where T : DbContext
	{
		private readonly T context;


		/// <summary>
		/// Constructor for <see cref="TransactionProvider{T}"/>
		/// </summary>
		/// <param name="context"></param>
		public TransactionProvider(T context)
		{
			this.context = context;
		}


		IDbContextTransaction ITransactionProvider.CreateTransaction()
			=> context.Database.BeginTransaction();

		Task<IDbContextTransaction> ITransactionProvider.CreateTransactionAsync()
			=> context.Database.BeginTransactionAsync();
	}
}
