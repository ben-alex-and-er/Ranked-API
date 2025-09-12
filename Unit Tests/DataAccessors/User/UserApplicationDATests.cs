using Microsoft.EntityFrameworkCore;
using Ranked.Data.User.DTOs;
using Ranked.Data.User.Requests;
using Ranked.DataAccessors.User;
using Ranked.DataAccessors.User.Interfaces;
using Ranked.Models;
using TestRig.Database;


namespace Unit_Tests.DataAccessors.User
{
	using Data;


	internal class UserApplicationDATests
	{
		private IUserApplicationDA userApplicationDA;

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

			context.Users.Add(new Ranked.Models.User
			{
				Id = 5,
				Identifier = UserConsts.NEW_USER_1
			});


			context.Applications.Add(new Ranked.Models.Application
			{
				Id = 1,
				Name = AppConsts.APP_NAME,
				Guid = new Guid(AppConsts.APP_GUID),
			});


			context.UserApplications.Add(new UserApplication
			{
				UserId = 1,
				ApplicationId = 1
			});

			context.UserApplications.Add(new UserApplication
			{
				UserId = 2,
				ApplicationId = 1
			});

			context.UserApplications.Add(new UserApplication
			{
				UserId = 3,
				ApplicationId = 1
			});

			context.UserApplications.Add(new UserApplication
			{
				UserId = 4,
				ApplicationId = 1
			});


			await context.SaveChangesAsync();

			userApplicationDA = new UserApplicationDA(context);
		}


		[TearDown]
		public async Task TearDown()
		{
			await context.Database.EnsureDeletedAsync();
			await context.DisposeAsync();
		}


		[TestCaseSource(typeof(UserApplicationDATestCaseSources), nameof(UserApplicationDATestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string user, string application, bool success)
		{
			// Arrange
			var request = new CreateUserRequest(user, new Guid(application));

			// Act
			var result = await userApplicationDA.Create(request);

			// Assert
			Assert.Multiple(async () =>
			{
				Assert.That(result, Is.EqualTo(success));

				if (success)
				{
					var created = await context.UserApplications
						.Where(x => x.User.Identifier == user)
						.Where(x => x.Application.Guid == new Guid(application))
						.AnyAsync();

					Assert.That(created, Is.True);
				}
			});
		}

		[Test]
		public void ReadTest()
		{
			// Arrange
			var expectedResult = new List<UserApplicationDTO>()
			{
				new()
				{
					User = UserConsts.VALID_USER_1,
					Application = new Guid(AppConsts.APP_GUID)
				},
				new()
				{
					User = UserConsts.VALID_USER_2,
					Application = new Guid(AppConsts.APP_GUID)
				},
				new()
				{
					User = UserConsts.VALID_USER_3,
					Application = new Guid(AppConsts.APP_GUID)
				},
				new()
				{
					User = UserConsts.VALID_USER_4,
					Application = new Guid(AppConsts.APP_GUID)
				}
			};

			// Act
			var result = userApplicationDA.Read();

			// Assert
			Assert.That(result, Is.EquivalentTo(expectedResult));
		}
	}
}
