using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace Ranked.Configuration.Authorization
{
	using Providers.Authorization.Claims;
	using Providers.Authorization.Policy;


	public static class AuthorizationSetup
	{
		/// <summary>
		/// Adds authorization related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
		{
			services.AddAuthorization(SetupPolicies);

			return services;
		}


		private static void SetupPolicies(AuthorizationOptions options)
		{
			options.AddPolicy(Policies.User.READ, AddClaim(Permissions.User.read));
			options.AddPolicy(Policies.User.WRITE, AddClaim(Permissions.User.write));
			options.AddPolicy(Policies.User.DELETE, AddClaim(Permissions.User.delete));
		}

		private static Action<AuthorizationPolicyBuilder> AddClaim(Claim claim)
			=> builder => builder.RequireClaim(claim.Type, claim.Value);
	}
}
