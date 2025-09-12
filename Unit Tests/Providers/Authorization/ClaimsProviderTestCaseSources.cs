using Ranked.Providers.Authorization.Claims;
using System.Security.Claims;


namespace Unit_Tests.Providers.Authorization
{
	internal static class ClaimsProviderTestCaseSources
	{
		public static IEnumerable<TestCaseData> GetClaimsTestCaseSource
		{
			get
			{
				yield return new TestCaseData(Permissions.Roles.READER, new List<Claim>() { new(ClaimTypes.Role, Permissions.Roles.READER) });
				yield return new TestCaseData(Permissions.Roles.ADMIN, new List<Claim>() { new(ClaimTypes.Role, Permissions.Roles.ADMIN) });
			}
		}
	}
}
