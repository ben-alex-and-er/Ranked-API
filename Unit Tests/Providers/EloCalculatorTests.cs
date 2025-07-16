using Ranked.Providers.Elo;


namespace Unit_Tests.Providers
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
	}
}
