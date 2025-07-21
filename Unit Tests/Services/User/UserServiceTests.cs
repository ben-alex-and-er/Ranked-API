using Ranked.Data.User.Requests;
using Ranked.Data.User.Status;
using Ranked.Services.User;
using Ranked.Services.User.Interfaces;


namespace Unit_Tests.Services.User
{
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
				UserDACreator.CreateUserDA(),
				EloDACreator.CreateUserEloDA());
		}


		[TestCaseSource(typeof(UserServiceTestCaseSources), nameof(UserServiceTestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string user, CreateUserStatus expectedResult)
		{
			// Arrange
			var request = new CreateUserRequest(user);

			// Act
			var result = await userService.Create(request);

			// Assert
			Assert.That(result.Status, Is.EqualTo(expectedResult));
		}
	}
}
