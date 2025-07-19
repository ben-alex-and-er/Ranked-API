using Microsoft.EntityFrameworkCore.Storage;
using NSubstitute;
using TransactionToolkit.Interfaces;


namespace Unit_Tests.ProviderCreators.Transaction
{
	internal static class TransactionProviderCreator
	{
		public static ITransactionCreator CreateTransactionCreator()
		{
			var provider = Substitute.For<ITransactionCreator>();

			var transaction = Substitute.For<IDbContextTransaction>();


			provider.CreateTransaction()
				.Returns(transaction);

			provider.CreateTransactionAsync()
				.Returns(transaction);


			return provider;
		}
	}
}
