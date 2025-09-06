using Ranked.Data.Elo.DTOs;
using Ranked.Data.Elo.Responses;
using Ranked.Data.Elo.Status;
using Ranked.Data.User.DTOs;


namespace Unit_Tests.Services.Elo
{
	using Data;


	internal static class EloServiceTestCaseSources
	{
		public static IEnumerable<TestCaseData> _1V1TestCaseSource
		{
			get
			{
				yield return new TestCaseData(
					new UserApplicationDTO { User = UserConsts.VALID_USER_1, Application = new Guid(AppConsts.APP_GUID) },
					new UserApplicationDTO { User = UserConsts.VALID_USER_2, Application = new Guid(AppConsts.APP_GUID) },
					_1v1Status.SUCCESS,
					new _1v1Response(
						new UserApplicationEloDTO { UserApplication = new UserApplicationDTO { User = UserConsts.VALID_USER_1, Application = new Guid(AppConsts.APP_GUID) }, Elo = 1016 },
						new UserApplicationEloDTO { UserApplication = new UserApplicationDTO { User = UserConsts.VALID_USER_2, Application = new Guid(AppConsts.APP_GUID) }, Elo = 984 }));

				yield return new TestCaseData(
					new UserApplicationDTO { User = UserConsts.INVALID_USER_1, Application = new Guid(AppConsts.APP_GUID) },
					new UserApplicationDTO { User = UserConsts.VALID_USER_2, Application = new Guid(AppConsts.APP_GUID) },
					_1v1Status.WINNER_IDENTIFIER_NOT_FOUND,
					null);
				yield return new TestCaseData(
					new UserApplicationDTO { User = UserConsts.VALID_USER_1, Application = new Guid(AppConsts.APP_GUID) },
					new UserApplicationDTO { User = UserConsts.INVALID_USER_2, Application = new Guid(AppConsts.APP_GUID) },
					_1v1Status.LOSER_IDENTIFIER_NOT_FOUND,
					null);

				yield return new TestCaseData(new UserApplicationDTO { User = UserConsts.VALID_USER_3, Application = new Guid(AppConsts.APP_GUID) },
					new UserApplicationDTO { User = UserConsts.VALID_USER_2, Application = new Guid(AppConsts.APP_GUID) },
					_1v1Status.WINNER_ELO_UPDATE_FAILED,
					null);
				yield return new TestCaseData(
					new UserApplicationDTO { User = UserConsts.VALID_USER_1, Application = new Guid(AppConsts.APP_GUID) },
					new UserApplicationDTO { User = UserConsts.VALID_USER_4, Application = new Guid(AppConsts.APP_GUID) },
					_1v1Status.LOSER_ELO_UPDATE_FAILED,
					null);
			}
		}
	}
}
