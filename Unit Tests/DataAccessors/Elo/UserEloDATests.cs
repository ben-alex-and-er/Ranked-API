using Microsoft.EntityFrameworkCore;
using Ranked.Data.Elo.DTOs;
using Ranked.Data.User.DTOs;
using Ranked.DataAccessors.Elo;
using Ranked.DataAccessors.Elo.Interfaces;
using Ranked.Models;
using TestRig.Database;


namespace Unit_Tests.DataAccessors.Elo
{
	using Data;


	internal class UserEloDATests
	{
		private IUserApplicationEloDA userEloDA;

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

			context.Applications.Add(new Application
			{
				Id = 1,
				Name = "Global",
				Guid = new Guid(AppConsts.APP_GUID)
			});

			context.UserApplications.Add(new UserApplication
			{
				Id = 1,
				UserId = 1,
				ApplicationId = 1
			});

			context.UserApplications.Add(new UserApplication
			{
				Id = 2,
				UserId = 2,
				ApplicationId = 1
			});

			context.UserApplications.Add(new UserApplication
			{
				Id = 3,
				UserId = 3,
				ApplicationId = 1
			});

			context.UserApplications.Add(new UserApplication
			{
				Id = 4,
				UserId = 4,
				ApplicationId = 1
			});

			context.UserApplicationElos.Add(new UserApplicationElo
			{
				UserApplicationId = 1,
				Elo = 1000
			});

			context.UserApplicationElos.Add(new UserApplicationElo
			{
				UserApplicationId = 2,
				Elo = 2000
			});

			context.UserApplicationElos.Add(new UserApplicationElo
			{
				UserApplicationId = 3,
				Elo = 3000
			});

			await context.SaveChangesAsync();

			userEloDA = new UserApplicationEloDA(context);
		}


		[TearDown]
		public async Task TearDown()
		{
			await context.Database.EnsureDeletedAsync();
			await context.DisposeAsync();
		}


		[TestCaseSource(typeof(UserEloDATestCaseSources), nameof(UserEloDATestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string user, string application, int elo, bool success)
		{
			// Arrange
			var userElo = new UserApplicationEloDTO
			{
				UserApplication = new UserApplicationDTO
				{
					User = user,
					Application = new Guid(application)
				},
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
					var created = await context.UserApplicationElos
						.Where(x => x.UserApplication.User.Identifier == user)
						.Where(x => x.UserApplication.Application.Guid == new Guid(application))
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
			var expectedResult = new List<UserApplicationEloDTO>()
			{
				new()
				{
					UserApplication = new UserApplicationDTO
					{
						User = UserConsts.VALID_USER_1,
						Application = new Guid(AppConsts.APP_GUID)
					},
					Elo = 1000
				},
				new()
				{
					UserApplication = new UserApplicationDTO
					{
						User = UserConsts.VALID_USER_2,
						Application = new Guid(AppConsts.APP_GUID)
					},
					Elo = 2000
				},
				new()
				{
					UserApplication = new UserApplicationDTO
					{
						User = UserConsts.VALID_USER_3,
						Application = new Guid(AppConsts.APP_GUID)
					},
					Elo = 3000
				}
			};

			// Act
			var result = userEloDA.Read();

			// Assert
			Assert.That(result, Is.EquivalentTo(expectedResult));
		}

		[TestCaseSource(typeof(UserEloDATestCaseSources), nameof(UserEloDATestCaseSources.UpdateTestCaseSource))]
		public async Task UpdateTests(string user, string application, int elo, bool success)
		{
			// Arrange
			var userApp = new UserApplicationDTO
			{
				User = user,
				Application = new Guid(application)
			};

			// Act
			var result = await userEloDA.Update(userApp, (uint)elo);

			// Assert
			Assert.Multiple(async () =>
			{
				Assert.That(result, Is.EqualTo(success));

				if (success)
				{
					var updated = await context.UserApplicationElos
						.Where(x => x.UserApplication.User.Identifier == user)
						.Where(x => x.UserApplication.Application.Guid == new Guid(application))
						.Where(x => x.Elo == elo)
						.AnyAsync();

					Assert.That(updated, Is.True);
				}
			});
		}
	}
}
