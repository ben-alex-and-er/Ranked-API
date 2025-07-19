using NSubstitute;
using Ranked.DataAccessors.User.Interfaces;


namespace Unit_Tests.DataAccessorCreators.User
{
	using Data;
	using TestHelpers;


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
	}
}
