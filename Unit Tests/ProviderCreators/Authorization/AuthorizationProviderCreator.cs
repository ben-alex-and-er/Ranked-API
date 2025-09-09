using GateKeeper.Cryptography;
using NSubstitute;
using Ranked.Providers.Authorization.Interfaces;
using System.Security.Claims;
using TestRig.Extensions;


namespace Unit_Tests.ProviderCreators.Authorization
{
	using Data;


	internal static class AuthorizationProviderCreator
	{
		public static IClaimsProvider CreateClaimsProvider()
		{
			var provider = Substitute.For<IClaimsProvider>();

			provider.GetSubjectClaims(Arg.Any<string>())
				.Returns(new List<Claim>()
				{
					AuthConsts.Claim
				}.AsEFTestQueryable());

			return provider;
		}


		public static IRoleProvider CreateRoleProvider()
		{
			var provider = Substitute.For<IRoleProvider>();

			provider.GetHashedPassword(AuthConsts.SUBJECT)
				.Returns(PasswordHasher.HashPassword(AuthConsts.PASSWORD).ToString());

			return provider;
		}
	}
}
