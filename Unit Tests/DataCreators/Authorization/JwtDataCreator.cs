using NSubstitute;
using Ranked.Data.Security.Interfaces;


namespace Unit_Tests.DataCreators.Authorization
{
	using Data;


	internal static class JwtDataCreator
	{
		public static IJwtDescriptor CreatJwtDescriptor()
		{
			var jwtDescriptor = Substitute.For<IJwtDescriptor>();

			jwtDescriptor.Issuer
				.Returns(AuthConsts.JWT_ISSUER);

			jwtDescriptor.Audience
				.Returns(AuthConsts.JWT_AUDIENCE);

			jwtDescriptor.SecurityKey
				.Returns(AuthConsts.JWT_SECURITY_KEY);

			return jwtDescriptor;
		}
	}
}
