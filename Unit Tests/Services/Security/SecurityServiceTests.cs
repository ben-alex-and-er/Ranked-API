using Microsoft.AspNetCore.Mvc;
using Ranked.Data.Security.Request;
using Ranked.Services.Security;
using Ranked.Services.Security.Interfaces;


namespace Unit_Tests.Services.Security
{
	using DataCreators.Authorization;
	using ProviderCreators.Authorization;


	internal class SecurityServiceTests
	{
		private ISecurityService securityService;


		[SetUp]
		public void SetUp()
		{
			var jwtDescriptor = JwtDataCreator.CreatJwtDescriptor();

			var claimsProvider = AuthorizationProviderCreator.CreateClaimsProvider();

			var roleProvider = AuthorizationProviderCreator.CreateRoleProvider();

			securityService = new SecurityService(
				jwtDescriptor,
				claimsProvider,
				roleProvider);
		}


		[TestCaseSource(typeof(SecurityServiceTestCaseSources), nameof(SecurityServiceTestCaseSources.GetPolicyTokenTestCaseSource))]
		public async Task GetPolicyTokenTests(string subject, string password, Type expectedType, int expectedStatusCode)
		{
			// Arrange
			var request = new PolicyRequest(subject, password);

			// Act
			var result = await securityService.GetPolicyToken(request);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.TypeOf(expectedType));
				var objectResult = (ObjectResult)result;
				Assert.That(objectResult.Value, Is.Not.Null);
				Assert.That(objectResult.Value, Is.Not.Empty);
				Assert.That(objectResult.StatusCode, Is.EqualTo(expectedStatusCode));
			});
		}
	}
}
