using NSubstitute;
using Ranked.Data.Elo.DTOs;
using Ranked.Data.Elo.Requests;
using Ranked.Data.Elo.Responses;
using Ranked.Data.Elo.Status;
using Ranked.DataAccessors.Elo.Interfaces;
using Ranked.Services.Elo;
using Ranked.Services.Elo.Interfaces;


namespace Unit_Tests.Services.Elo
{
	using Data;
	using TestHelpers;


	internal class EloServiceTests
	{
		private IEloService eloService;


		[SetUp]
		public void SetUp()
		{
			var da = Substitute.For<IUserEloDA>();

			da.Read()
				.Returns(new List<UserEloDTO>()
				{
					new()
					{
						User = UserConsts.VALID_USER_1,
						Elo = 1000
					},
					new()
					{
						User = UserConsts.VALID_USER_2,
						Elo = 1000
					},
					new()
					{
						User = UserConsts.VALID_USER_3,
						Elo = 1134
					},
					new()
					{
						User = UserConsts.VALID_USER_4,
						Elo = 926
					},
				}.AsEFTestQueryable());


			da.Update(Arg.Any<string>(), Arg.Any<uint>())
				.Returns(false);

			da.Update(Arg.Is(UserConsts.VALID_USER_1), Arg.Any<uint>())
				.Returns(true);

			da.Update(Arg.Is(UserConsts.VALID_USER_2), Arg.Any<uint>())
				.Returns(true);


			eloService = new EloService(da);
		}


		[TestCaseSource(typeof(EloServiceTestCaseSources), nameof(EloServiceTestCaseSources._1V1TestCaseSource))]
		public async Task _1v1Tests(string winner, string loser, _1v1Status expectedStatus, _1v1Response expectedResponse)
		{
			// Arrange
			var request = new _1v1Request(winner, loser);

			// Act
			var result = await eloService._1v1(request);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Status, Is.EqualTo(expectedStatus));

				// If fail
				if (result.Value == null)
				{
					Assert.That(result.Value, Is.EqualTo(expectedResponse));
				}
				// If succeeds, verify response
				else
				{
					Assert.That(result.Value.Winner, Is.EqualTo(expectedResponse.Winner));
					Assert.That(result.Value.Loser, Is.EqualTo(expectedResponse.Loser));
				}
			});
		}
	}
}
