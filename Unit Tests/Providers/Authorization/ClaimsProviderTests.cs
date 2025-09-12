using Ranked.Providers.Authorization;
using Ranked.Providers.Authorization.Interfaces;
using System.Security.Claims;


namespace Unit_Tests.Providers.Authorization
{
	internal class ClaimsProviderTests
	{
		private IClaimsProvider claimsProvider;


		[SetUp]
		public void SetUp()
		{
			claimsProvider = new ClaimsProvider();
		}


		[TestCaseSource(typeof(ClaimsProviderTestCaseSources), nameof(ClaimsProviderTestCaseSources.GetClaimsTestCaseSource))]
		public void GetClaimsTests(string role, List<Claim> expectedClaims)
		{
			var result = claimsProvider.GetClaims(role);

			Assert.That(result, Is.Not.Null);
			Assert.That(
				result.Select(claim => new { claim.Type, claim.Value }),
				Is.EquivalentTo(expectedClaims.Select(claim => new { claim.Type, claim.Value })));
		}
	}
}
