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
				yield return new TestCaseData(UserConsts.NEW_USER_1, AppConsts.APP_GUID, CreateUserStatus.SUCCESS);

				yield return new TestCaseData(UserConsts.NEW_USER_1, Guid.Empty.ToString(), CreateUserStatus.APPLICATION_NOT_FOUND);
				yield return new TestCaseData(UserConsts.VALID_USER_1, AppConsts.APP_GUID, CreateUserStatus.USER_APPLICATION_ALREADY_EXISTS);
				yield return new TestCaseData(UserConsts.INVALID_USER_1, AppConsts.APP_GUID, CreateUserStatus.FAILED_TO_CREATE_ELO);
			}
		}
	}
}
