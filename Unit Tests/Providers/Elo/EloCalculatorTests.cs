using Ranked.Data.Elo.DTOs;
using Ranked.Providers.Elo;


namespace Unit_Tests.Providers.Elo
{
	internal class EloCalculatorTests
	{
		[TestCaseSource(typeof(EloCalculatorTestCaseSources), nameof(EloCalculatorTestCaseSources.Calculate1V1TestCaseSource))]
		public void Calculate1V1Tests((int winner, int loser) request, int maxEloChange, (int winnner, int loser) expected)
		{
			// Act
			var result = EloCalculator.Calculate1V1((uint)request.winner, (uint)request.loser, (uint)maxEloChange);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCaseSource(typeof(EloCalculatorTestCaseSources), nameof(EloCalculatorTestCaseSources.CalculateElosTestCaseSource))]
		public void CalculateEloTests(
			List<UserApplicationEloDTO> winners,
			List<UserApplicationEloDTO> losers,
			int maxEloChange,
			List<UserApplicationEloDTO> expectedWinners,
			List<UserApplicationEloDTO> expectedLosers)
		{
			// Act
			var result = EloCalculator.CalculateElos(winners, losers, (uint)maxEloChange);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Item1, Is.EquivalentTo(expectedWinners));
				Assert.That(result.Item2, Is.EquivalentTo(expectedLosers));
			});
		}

		[TestCaseSource(typeof(EloCalculatorTestCaseSources), nameof(EloCalculatorTestCaseSources.CalculateWeightedElosTestCaseSource))]
		public void CalculateElosWithWeightedTeamsTests(
			List<UserApplicationEloDTO> winners,
			List<UserApplicationEloDTO> losers,
			int maxEloChange,
			List<UserApplicationEloDTO> expectedWinners,
			List<UserApplicationEloDTO> expectedLosers)
		{
			// Act
			var result = EloCalculator.CalculateWeightedElos(winners, losers, (uint)maxEloChange);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Item1, Is.EquivalentTo(expectedWinners));
				Assert.That(result.Item2, Is.EquivalentTo(expectedLosers));
			});
		}
	}
}
