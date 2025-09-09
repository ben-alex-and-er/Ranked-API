using Ranked.Providers.Authorization;
using Ranked.Providers.Authorization.Interfaces;


namespace Unit_Tests.Providers.Authorization
{
	using DataAccessorCreators.Authorization;


	internal class RoleProviderTests
	{
		private IRoleProvider roleProvider;


		[SetUp]
		public void SetUp()
		{
			roleProvider = new RoleProvider(AuthorizationDACreator.CreateRolePasswordDA());
		}


		[TestCaseSource(typeof(RoleProviderTestCaseSources), nameof(RoleProviderTestCaseSources.GetHashedPasswordTestCaseSource))]
		public async Task GetHashedPasswordTests(string subject, string? expectedHashedPassword)
		{
			var result = await roleProvider.GetHashedPassword(subject);

			Assert.That(result, Is.EqualTo(expectedHashedPassword));
		}
	}
}
