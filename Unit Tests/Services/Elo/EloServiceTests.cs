using Ranked.Data.Elo.Requests;
using Ranked.Data.Elo.Responses;
using Ranked.Data.Elo.Status;
using Ranked.Services.Elo;
using Ranked.Services.Elo.Interfaces;


namespace Unit_Tests.Services.Elo
{
	using DataAccessorCreators.Elo;


	internal class EloServiceTests
	{
		private IEloService eloService;


		[SetUp]
		public void SetUp()
		{
			eloService = new EloService(EloDACreator.CreateUserEloDA());
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
