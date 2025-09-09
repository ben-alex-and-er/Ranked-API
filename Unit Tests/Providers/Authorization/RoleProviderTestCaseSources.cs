namespace Unit_Tests.Providers.Authorization
{
	using Data;


	internal static class RoleProviderTestCaseSources
	{
		public static IEnumerable<TestCaseData> GetHashedPasswordTestCaseSource
		{
			get
			{
				yield return new TestCaseData(AuthConsts.SUBJECT, AuthConsts.PASSWORD);
				yield return new TestCaseData(string.Empty, null);
			}
		}
	}
}
