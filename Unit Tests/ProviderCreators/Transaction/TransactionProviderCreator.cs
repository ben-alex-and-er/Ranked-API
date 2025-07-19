using Microsoft.EntityFrameworkCore.Storage;
using NSubstitute;
using Ranked.Providers.Transaction.Interfaces;


namespace Unit_Tests.ProviderCreators.Transaction
{
	internal static class TransactionProviderCreator
	{
		public static ITransactionProvider CreateTransactionProvider()
		{
			var provider = Substitute.For<ITransactionProvider>();

			var transaction = Substitute.For<IDbContextTransaction>();


			provider.CreateTransaction()
				.Returns(transaction);

			provider.CreateTransactionAsync()
				.Returns(transaction);


			return provider;
		}
	}
}
