namespace Ranked.Configuration.Transaction
{
	using Models;
	using Providers.Transaction;
	using Providers.Transaction.Interfaces;


	public static class TransactionSetup
	{
		/// <summary>
		/// Adds transaction related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddTransactionServices(this IServiceCollection services)
		{
			services.AddTransient<ITransactionProvider, TransactionProvider<RankedContext>>();

			return services;
		}
	}
}
