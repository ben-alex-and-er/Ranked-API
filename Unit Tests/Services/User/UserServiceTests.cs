using Ranked.Data.User.Requests;
using Ranked.Data.User.Status;
using Ranked.Services.User;
using Ranked.Services.User.Interfaces;


namespace Unit_Tests.Services.User
{
	using DataAccessorCreators.Application;
	using DataAccessorCreators.Elo;
	using DataAccessorCreators.User;
	using ProviderCreators.Transaction;


	internal class UserServiceTests
	{
		private IUserService userService;


		[SetUp]
		public void SetUp()
		{
			userService = new UserService(
				TransactionProviderCreator.CreateTransactionCreator(),
				ApplicationDACreator.CreateApplicationDA(),
				UserDACreator.CreateUserDA(),
				UserDACreator.CreateUserApplicationDA(),
				EloDACreator.CreateUserApplicationEloDA());
		}


		[TestCaseSource(typeof(UserServiceTestCaseSources), nameof(UserServiceTestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string user, string application, CreateUserStatus expectedResult)
		{
			// Arrange
			var request = new CreateUserRequest(user, new Guid(application));

			// Act
			var result = await userService.Create(request);

			// Assert
			Assert.That(result.Status, Is.EqualTo(expectedResult));
		}
	}
}
