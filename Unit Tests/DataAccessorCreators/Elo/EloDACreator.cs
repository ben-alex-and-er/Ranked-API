using NSubstitute;
using Ranked.Data.Elo.DTOs;
using Ranked.DataAccessors.Elo.Interfaces;


namespace Unit_Tests.DataAccessorCreators.Elo
{
	using Data;
	using TestHelpers;


	internal static class EloDACreator
	{
		public static IUserEloDA CreateUserEloDA()
		{
			var da = Substitute.For<IUserEloDA>();


			da.Create(Arg.Is<UserEloDTO>(x => x.User == UserConsts.NEW_USER_1))
				.Returns(true);

			da.Create(Arg.Is<UserEloDTO>(x => x.User == UserConsts.NEW_USER_2))
				.Returns(true);

			da.Create(Arg.Is<UserEloDTO>(x => x.User == UserConsts.NEW_USER_3))
				.Returns(true);

			da.Create(Arg.Is<UserEloDTO>(x => x.User == UserConsts.NEW_USER_4))
				.Returns(true);


			da.Read()
				.Returns(new List<UserEloDTO>()
				{
					new()
					{
						User = UserConsts.VALID_USER_1,
						Elo = 1000
					},
					new()
					{
						User = UserConsts.VALID_USER_2,
						Elo = 1000
					},
					new()
					{
						User = UserConsts.VALID_USER_3,
						Elo = 1134
					},
					new()
					{
						User = UserConsts.VALID_USER_4,
						Elo = 926
					}
				}.AsEFTestQueryable());


			da.Update(Arg.Is(UserConsts.VALID_USER_1), Arg.Any<uint>())
				.Returns(true);

			da.Update(Arg.Is(UserConsts.VALID_USER_2), Arg.Any<uint>())
				.Returns(true);


			return da;
		}
	}
}
