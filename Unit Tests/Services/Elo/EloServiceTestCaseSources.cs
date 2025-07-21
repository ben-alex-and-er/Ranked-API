using Ranked.Data.Elo.DTOs;
using Ranked.Data.Elo.Responses;
using Ranked.Data.Elo.Status;


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
					UserConsts.VALID_USER_1,
					UserConsts.VALID_USER_2,
					_1v1Status.SUCCESS,
					new _1v1Response(
						new UserEloDTO { User = UserConsts.VALID_USER_1, Elo = 1016 },
						new UserEloDTO { User = UserConsts.VALID_USER_2, Elo = 984 }));

				yield return new TestCaseData(UserConsts.INVALID_USER_1, UserConsts.VALID_USER_2, _1v1Status.WINNER_IDENTIFIER_NOT_FOUND, null);
				yield return new TestCaseData(UserConsts.VALID_USER_1, UserConsts.INVALID_USER_2, _1v1Status.LOSER_IDENTIFIER_NOT_FOUND, null);

				yield return new TestCaseData(UserConsts.VALID_USER_3, UserConsts.VALID_USER_2, _1v1Status.WINNER_ELO_UPDATE_FAILED, null);
				yield return new TestCaseData(UserConsts.VALID_USER_1, UserConsts.VALID_USER_4, _1v1Status.LOSER_ELO_UPDATE_FAILED, null);
			}
		}
	}
}
