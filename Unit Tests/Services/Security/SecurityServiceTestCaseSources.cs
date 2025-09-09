using Microsoft.AspNetCore.Mvc;


namespace Unit_Tests.Services.Security
{
	using Data;


	internal static class SecurityServiceTestCaseSources
	{
		public static IEnumerable<TestCaseData> GetPolicyTokenTestCaseSource
		{
			get
			{
				yield return new TestCaseData("Fake Subject", AuthConsts.PASSWORD, typeof(UnauthorizedObjectResult), 401);
				yield return new TestCaseData(AuthConsts.SUBJECT, "Fake Password", typeof(UnauthorizedObjectResult), 401);
				yield return new TestCaseData(AuthConsts.SUBJECT, AuthConsts.PASSWORD, typeof(OkObjectResult), 200);
			}
		}
	}
}
