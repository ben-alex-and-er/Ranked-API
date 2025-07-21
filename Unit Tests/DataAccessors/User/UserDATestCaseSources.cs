namespace Unit_Tests.DataAccessors.User
{
	using Data;


	internal static class UserDATestCaseSources
	{
		public static IEnumerable<TestCaseData> CreateTestCaseSource
		{
			get
			{
				yield return new TestCaseData(UserConsts.NEW_USER_1, true);
				yield return new TestCaseData(UserConsts.VALID_USER_1, false);
			}
		}
	}
}
