namespace Unit_Tests.DataAccessors.Elo
{
	using Data;


	internal class UserEloDATestCaseSources
	{
		public static IEnumerable<TestCaseData> CreateTestCaseSource
		{
			get
			{
				yield return new TestCaseData(UserConsts.NEW_USER_1, 1000, false);
				yield return new TestCaseData(UserConsts.VALID_USER_1, 1000, false);
				yield return new TestCaseData(UserConsts.VALID_USER_4, 4000, true);
			}
		}

		public static IEnumerable<TestCaseData> UpdateTestCaseSource
		{
			get
			{
				yield return new TestCaseData(UserConsts.NEW_USER_1, 1000, false);
				yield return new TestCaseData(UserConsts.VALID_USER_4, 4000, false);
				yield return new TestCaseData(UserConsts.VALID_USER_1, 2000, true);
			}
		}
	}
}
