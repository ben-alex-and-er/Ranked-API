using NSubstitute;
using Ranked.Data.Authorization.DTOs;
using Ranked.DataAccessors.Authorization.Interfaces;
using TestRig.Extensions;


namespace Unit_Tests.DataAccessorCreators.Authorization
{
	using Data;


	internal static class AuthorizationDACreator
	{
		public static IRolePasswordDA CreateRolePasswordDA()
		{
			var da = Substitute.For<IRolePasswordDA>();

			da.Read()
				.Returns(new List<SubjectPasswordDTO>()
				{
					new()
					{
						Subject = AuthConsts.SUBJECT,
						Password = AuthConsts.PASSWORD
					}
				}.AsEFTestQueryable());

			return da;
		}
	}
}
