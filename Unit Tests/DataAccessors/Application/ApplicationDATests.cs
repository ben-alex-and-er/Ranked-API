using Microsoft.EntityFrameworkCore;
using Ranked.Data.Application.Requests;
using Ranked.Data.Common.DTOs;
using Ranked.DataAccessors.Application;
using Ranked.DataAccessors.Application.Interfaces;
using Ranked.Models;
using TestRig.Database;


namespace Unit_Tests.DataAccessors.Application
{
	using Data;


	internal class ApplicationDATests
	{
		private IApplicationDA applicationDA;

		private RankedContext context;


		[SetUp]
		public async Task Setup()
		{
			context = new MockDbContextFactory<RankedContext>().CreateDbContext();

			context.Applications.Add(new Ranked.Models.Application
			{
				Name = AppConsts.APP_NAME,
				Guid = new Guid(AppConsts.APP_GUID)
			});


			await context.SaveChangesAsync();

			applicationDA = new ApplicationDA(context);
		}


		[TearDown]
		public async Task TearDown()
		{
			await context.Database.EnsureDeletedAsync();
			await context.DisposeAsync();
		}


		[TestCaseSource(typeof(ApplicationDATestCaseSources), nameof(ApplicationDATestCaseSources.CreateTestCaseSource))]
		public async Task CreateTests(string name, string guid, bool success)
		{
			// Arrange
			var request = new CreateApplicationRequest
			{
				Name = name,
				Guid = new Guid(guid)
			};

			// Act
			var result = await applicationDA.Create(request);

			// Assert
			Assert.Multiple(async () =>
			{
				Assert.That(result, Is.EqualTo(success));

				if (success)
				{
					var created = await context.Applications
						.Where(x => x.Name == name)
						.Where(x => x.Guid == new Guid(guid))
						.AnyAsync();

					Assert.That(created, Is.True);
				}
			});
		}

		[Test]
		public void ReadTest()
		{
			// Arrange
			var expectedResult = new List<NameGuidDTO>()
			{
				new()
				{
					Name = AppConsts.APP_NAME,
					Guid = new Guid(AppConsts.APP_GUID)
				}
			};

			// Act
			var result = applicationDA.Read();

			// Assert
			Assert.That(result, Is.EquivalentTo(expectedResult));
		}
	}
}
