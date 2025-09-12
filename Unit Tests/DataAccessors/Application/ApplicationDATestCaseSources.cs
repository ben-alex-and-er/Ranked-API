namespace Unit_Tests.DataAccessors.Application
{
	using Data;


	internal class ApplicationDATestCaseSources
	{
		public static IEnumerable<TestCaseData> CreateTestCaseSource
		{
			get
			{
				yield return new TestCaseData(Guid.Empty.ToString(), Guid.Empty.ToString(), true);
				yield return new TestCaseData(Guid.Empty.ToString(), AppConsts.APP_GUID, false);
				yield return new TestCaseData(AppConsts.APP_NAME, Guid.Empty.ToString(), false);
			}
		}
	}
}
