using Microsoft.EntityFrameworkCore;
using Ranked.DataAccessors.User;
using Ranked.DataAccessors.User.Interfaces;
using Ranked.Models;


namespace Unit_Tests.DataAccessors.User
{
	using Data;
	using TestHelpers;


	internal class UserDATests
	{
		private IUserDA userDA;

		private RankedContext context;


		[SetUp]
		public async Task Setup()
		{
			context = new MockDbContextFactory<RankedContext>().CreateDbContext();

			context.Users.Add(new Ranked.Models.User
			{
				Identifier = UserConsts.VALID_USER_1
			});

			context.Users.Add(new Ranked.Models.User
			{
				Identifier = UserConsts.VALID_USER_2
			});

			context.Users.Add(new Ranked.Models.User
			{
				Identifier = UserConsts.VALID_USER_3
			});

			context.Users.Add(new Ranked.Models.User
			{
				Identifier = UserConsts.VALID_USER_4
			});

			await context.SaveChangesAsync();

			userDA = new UserDA(context);
		}


		[TearDown]
		public async Task TearDown()
		{
			await context.Database.EnsureDeletedAsync();
			await context.DisposeAsync();
		}


		[TestCaseSource(typeof(UserDATestCaseSources), nameof(UserDATestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string user, bool success)
		{
			// Act
			var result = await userDA.Create(user);

			// Assert
			Assert.Multiple(async () =>
			{
				Assert.That(result, Is.EqualTo(success));

				if (success)
				{
					var created = await context.Users
						.Where(x => x.Identifier == user)
						.AnyAsync();

					Assert.That(created, Is.True);
				}
			});
		}

		[Test]
		public void ReadTest()
		{
			// Arrange
			var expectedResult = new List<string>()
			{
				UserConsts.VALID_USER_1,
				UserConsts.VALID_USER_2,
				UserConsts.VALID_USER_3,
				UserConsts.VALID_USER_4
			};

			// Act
			var result = userDA.Read();

			// Assert
			Assert.That(result, Is.EquivalentTo(expectedResult));
		}
	}
}
