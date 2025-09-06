namespace Unit_Tests.DataAccessors.User
{
	using Data;


	internal static class UserApplicationDATestCaseSources
	{
		public static IEnumerable<TestCaseData> CreateTestCaseSource
		{
			get
			{
				yield return new TestCaseData(UserConsts.NEW_USER_1, AppConsts.APP_GUID, true);
				yield return new TestCaseData(UserConsts.VALID_USER_1, AppConsts.APP_GUID, false);
				yield return new TestCaseData(UserConsts.NEW_USER_1, Guid.Empty.ToString(), false);
			}
		}
	}
}
