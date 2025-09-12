using NSubstitute;
using Ranked.Data.User.Requests;
using Ranked.Data.User.Status;
using Ranked.DataAccessors.User.Interfaces;
using Ranked.Services.User;
using Ranked.Services.User.Interfaces;
using TestRig.Extensions;


namespace Unit_Tests.Services.User
{
	using Data;
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

		[Test]
		public void CreateThrowsTests()
		{
			// Arrange
			var userDA = Substitute.For<IUserDA>();

			userDA.Create(UserConsts.NEW_USER_1)
				.Returns(false);

			userDA.Read()
				.Returns(new List<string>
				{

				}.AsEFTestQueryable());

			userService = new UserService(
				TransactionProviderCreator.CreateTransactionCreator(),
				ApplicationDACreator.CreateApplicationDA(),
				userDA,
				UserDACreator.CreateUserApplicationDA(),
				EloDACreator.CreateUserApplicationEloDA());

			var request = new CreateUserRequest(UserConsts.NEW_USER_1, new Guid(AppConsts.APP_GUID));

			// Act/Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () => await userService.Create(request));
		}
	}
}
