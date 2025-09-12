using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace Ranked.Configuration.Authorization
{
	using Data.Security;
	using DataAccessors.Authorization;
	using DataAccessors.Authorization.Interfaces;
	using Providers.Authorization;
	using Providers.Authorization.Interfaces;
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

			services.AddScoped<IClaimsTransformation, ClaimsTransformation>();

			services.AddTransient<IClaimsProvider, ClaimsProvider>();
			services.AddTransient<IRoleProvider, RoleProvider>();

			services.AddTransient<IRolePasswordDA, RolePasswordDA>();

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
