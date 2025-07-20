using Microsoft.AspNetCore.Authentication;


namespace Ranked.Configuration.Security
{
	using Providers.Authorization;
	using Providers.Authorization.Interfaces;
	using Services.Security;
	using Services.Security.Interfaces;


	public static class SecuritySetup
	{
		/// <summary>
		/// Adds authentication related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSecurityServices(this IServiceCollection services)
		{
			services.AddScoped<IClaimsTransformation, ClaimsTransformation>();

			services.AddTransient<ISecurityService, SecurityService>();

			services.AddTransient<IClaimsProvider, ClaimsProvider>();
			services.AddTransient<IRoleProvider, RoleProvider>();

			return services;
		}
	}
}
