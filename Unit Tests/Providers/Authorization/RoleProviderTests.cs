using Ranked.Providers.Authorization;
using Ranked.Providers.Authorization.Claims;
using Ranked.Providers.Authorization.Interfaces;


namespace Unit_Tests.Providers.Authorization
{
	internal class RoleProviderTests
	{
		private static readonly Dictionary<string, string> expectedResult = new()
		{
			{ Permissions.Roles.READER, "WjFWWmF6ZGFkV0l2VkU1Tk4wOUlLMkpQV2xaVGR6MDkuMTAwMDAwLlNIQTUxMi4zMi5lWFp0Tm1KMU5FZDBSa2RCTldOeWRtMW1ZbmN2TVhCa2NsbHFWMDFEZDNsT1FtZzVhVUZuUVZoU1RUMD0=" },
			{ Permissions.Roles.ADMIN, "WjFWWmF6ZGFkV0l2VkU1Tk4wOUlLMkpQV2xaVGR6MDkuMTAwMDAwLlNIQTUxMi4zMi5lWFp0Tm1KMU5FZDBSa2RCTldOeWRtMW1ZbmN2TVhCa2NsbHFWMDFEZDNsT1FtZzVhVUZuUVZoU1RUMD0=" }
		};

		private IRoleProvider roleProvider;


		[SetUp]
		public void SetUp()
		{
			roleProvider = new RoleProvider();
		}


		[Test]
		public async Task GetRolesTests()
		{
			var result = await roleProvider.GetRoles();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.EquivalentTo(expectedResult));
		}
	}
}
