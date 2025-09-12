using NSubstitute;
using Ranked.Data.Elo.DTOs;
using Ranked.Data.User.DTOs;
using Ranked.DataAccessors.Elo.Interfaces;
using TestRig.Extensions;


namespace Unit_Tests.DataAccessorCreators.Elo
{
	using Data;


	internal static class EloDACreator
	{
		public static IUserApplicationEloDA CreateUserApplicationEloDA()
		{
			var da = Substitute.For<IUserApplicationEloDA>();


			da.Create(Arg.Is<UserApplicationEloDTO>(x => x.UserApplication.User == UserConsts.NEW_USER_1))
				.Returns(true);

			da.Create(Arg.Is<UserApplicationEloDTO>(x => x.UserApplication.User == UserConsts.NEW_USER_2))
				.Returns(true);

			da.Create(Arg.Is<UserApplicationEloDTO>(x => x.UserApplication.User == UserConsts.NEW_USER_3))
				.Returns(true);

			da.Create(Arg.Is<UserApplicationEloDTO>(x => x.UserApplication.User == UserConsts.NEW_USER_4))
				.Returns(true);


			da.Read()
				.Returns(new List<UserApplicationEloDTO>()
				{
					new()
					{
						UserApplication = new UserApplicationDTO
						{
							User = UserConsts.VALID_USER_1,
							Application = new Guid(AppConsts.APP_GUID)
						},
						Elo = 1000
					},
					new()
					{
						UserApplication = new UserApplicationDTO
						{
							User = UserConsts.VALID_USER_2,
							Application = new Guid(AppConsts.APP_GUID)
						},
						Elo = 1000
					},
					new()
					{
						UserApplication = new UserApplicationDTO
						{
							User = UserConsts.VALID_USER_3,
							Application = new Guid(AppConsts.APP_GUID)
						},
						Elo = 1134
					},
					new()
					{
						UserApplication = new UserApplicationDTO
						{
							User = UserConsts.VALID_USER_4,
							Application = new Guid(AppConsts.APP_GUID)
						},
						Elo = 926
					}
				}.AsEFTestQueryable());


			da.Update(Arg.Is<UserApplicationDTO>(x => x.User == UserConsts.VALID_USER_1), Arg.Any<uint>())
				.Returns(true);

			da.Update(Arg.Is<UserApplicationDTO>(x => x.User == UserConsts.VALID_USER_2), Arg.Any<uint>())
				.Returns(true);


			return da;
		}
	}
}
