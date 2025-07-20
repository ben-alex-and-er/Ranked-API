using Microsoft.EntityFrameworkCore;
using Ranked.Data.Elo.DTOs;
using Ranked.DataAccessors.Elo;
using Ranked.DataAccessors.Elo.Interfaces;
using Ranked.Models;


namespace Unit_Tests.DataAccessors.Elo
{
	using Data;
	using TestHelpers;


	internal class UserEloDATests
	{
		private IUserEloDA userEloDA;

		private RankedContext context;


		[SetUp]
		public async Task Setup()
		{
			context = new MockDbContextFactory<RankedContext>().CreateDbContext();

			context.Users.Add(new Ranked.Models.User
			{
				Id = 1,
				Identifier = UserConsts.VALID_USER_1
			});

			context.Users.Add(new Ranked.Models.User
			{
				Id = 2,
				Identifier = UserConsts.VALID_USER_2
			});

			context.Users.Add(new Ranked.Models.User
			{
				Id = 3,
				Identifier = UserConsts.VALID_USER_3
			});

			context.Users.Add(new Ranked.Models.User
			{
				Id = 4,
				Identifier = UserConsts.VALID_USER_4
			});

			context.UserElos.Add(new UserElo
			{
				UserId = 1,
				Elo = 1000
			});

			context.UserElos.Add(new UserElo
			{
				UserId = 2,
				Elo = 2000
			});

			context.UserElos.Add(new UserElo
			{
				UserId = 3,
				Elo = 3000
			});

			await context.SaveChangesAsync();

			userEloDA = new UserEloDA(context);
		}


		[TearDown]
		public async Task TearDown()
		{
			await context.Database.EnsureDeletedAsync();
			await context.DisposeAsync();
		}


		[TestCaseSource(typeof(UserEloDATestCaseSources), nameof(UserEloDATestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string user, int elo, bool success)
		{
			// Arrange
			var userElo = new UserEloDTO
			{
				User = user,
				Elo = (uint)elo,
			};

			// Act
			var result = await userEloDA.Create(userElo);

			// Assert
			Assert.Multiple(async () =>
			{
				Assert.That(result, Is.EqualTo(success));

				if (success)
				{
					var created = await context.UserElos
						.Where(x => x.User.Identifier == user)
						.Where(x => x.Elo == elo)
						.AnyAsync();

					Assert.That(created, Is.True);
				}
			});
		}

		[Test]
		public void ReadTest()
		{
			// Arrange
			var expectedResult = new List<UserEloDTO>()
			{
				new()
				{
					User = UserConsts.VALID_USER_1,
					Elo = 1000
				},
				new()
				{
					User = UserConsts.VALID_USER_2,
					Elo = 2000
				},
				new()
				{
					User = UserConsts.VALID_USER_3,
					Elo = 3000
				}
			};

			// Act
			var result = userEloDA.Read();

			// Assert
			Assert.That(result, Is.EquivalentTo(expectedResult));
		}

		[TestCaseSource(typeof(UserEloDATestCaseSources), nameof(UserEloDATestCaseSources.UpdateTestCaseSource))]
		public async Task UpdateTests(string user, int elo, bool success)
		{
			// Act
			var result = await userEloDA.Update(user, (uint)elo);

			// Assert
			Assert.Multiple(async () =>
			{
				Assert.That(result, Is.EqualTo(success));

				if (success)
				{
					var updated = await context.UserElos
						.Where(x => x.User.Identifier == user)
						.Where(x => x.Elo == elo)
						.AnyAsync();

					Assert.That(updated, Is.True);
				}
			});
		}
	}
}
