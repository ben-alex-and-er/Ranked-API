using NSubstitute;
using Ranked.Data.User.DTOs;
using Ranked.DataAccessors.User.Interfaces;
using TestRig.Extensions;


namespace Unit_Tests.DataAccessorCreators.User
{
	using Data;
	using Microsoft.IdentityModel.Protocols.OpenIdConnect;
	using Ranked.Data.User.Interfaces;

	internal class UserDACreator
	{
		public static IUserDA CreateUserDA()
		{
			var da = Substitute.For<IUserDA>();


			da.Create(Arg.Is(UserConsts.NEW_USER_1))
				.Returns(true);

			da.Create(Arg.Is(UserConsts.NEW_USER_2))
				.Returns(true);

			da.Create(Arg.Is(UserConsts.NEW_USER_3))
				.Returns(true);

			da.Create(Arg.Is(UserConsts.NEW_USER_4))
				.Returns(true);

			da.Create(Arg.Is(UserConsts.INVALID_USER_1))
				.Returns(true);


			da.Read()
				.Returns(new List<string>()
				{
					UserConsts.VALID_USER_1,
					UserConsts.VALID_USER_2,
					UserConsts.VALID_USER_3,
					UserConsts.VALID_USER_4
				}.AsEFTestQueryable());


			return da;
		}

		public static IUserApplicationDA CreateUserApplicationDA()
		{
			var da = Substitute.For<IUserApplicationDA>();

			da.Create(Arg.Any<ICreateUserRequest>())
				.Returns(true);

			da.Create(Arg.Is<ICreateUserRequest>(x => x.User == UserConsts.VALID_USER_1))
				.Returns(false);

			da.Read()
				.Returns(new List<UserApplicationDTO>()
				{
					new()
					{
						User = UserConsts.VALID_USER_1,
						Application = new Guid(AppConsts.APP_GUID)
					},
					new()
					{
						User = UserConsts.VALID_USER_2,
						Application = new Guid(AppConsts.APP_GUID)
					},
					new()
					{
						User = UserConsts.VALID_USER_3,
						Application = new Guid(AppConsts.APP_GUID)
					},
					new()
					{
						User = UserConsts.VALID_USER_4,
						Application = new Guid(AppConsts.APP_GUID)
					}
				}.AsEFTestQueryable());

			return da;
		}
	}
}
