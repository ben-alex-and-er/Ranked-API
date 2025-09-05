using Microsoft.AspNetCore.Authorization;


namespace Ranked.Configuration.Authorization
{
	using Data.Security;
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
			options.AddPolicies([Policies.User.read, Policies.User.write, Policies.User.delete]);

			options.AddPolicies([Policies.Elo.read, Policies.Elo.write]);

			options.AddPolicies([Policies.Application.read, Policies.Application.write]);
		}

		private static void AddPolicies(this AuthorizationOptions options, IEnumerable<PolicyClaim> policyClaims)
		{
			foreach(var policyClaim in policyClaims)
			{
				options.AddPolicy(policyClaim.PolicyName, builder => builder.RequireClaim(policyClaim.Claim.Type, policyClaim.Claim.Value));
			}
		}
	}
}
