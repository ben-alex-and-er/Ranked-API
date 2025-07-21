using TransactionToolkit;
using TransactionToolkit.Interfaces;


namespace Ranked.Configuration.Transaction
{
	using Models;


	public static class TransactionSetup
	{
		/// <summary>
		/// Adds transaction related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddTransactionServices(this IServiceCollection services)
		{
			services.AddTransient<ITransactionCreator, TransactionCreator<RankedContext>>();

			return services;
		}
	}
}
