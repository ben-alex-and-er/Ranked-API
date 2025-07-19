using Ranked.Data.User.Status;


namespace Unit_Tests.Services.User
{
	using Data;


	internal static class UserServiceTestCaseSources
	{
		public static IEnumerable<TestCaseData> CreateTestCaseSource
		{
			get
			{
				yield return new TestCaseData(UserConsts.NEW_USER_1, CreateUserStatus.SUCCESS);
				yield return new TestCaseData(UserConsts.VALID_USER_1, CreateUserStatus.USER_ALREADY_EXISTS);
				yield return new TestCaseData(UserConsts.INVALID_USER_1, CreateUserStatus.FAILED_TO_CREATE_ELO);
			}
		}
	}
}
