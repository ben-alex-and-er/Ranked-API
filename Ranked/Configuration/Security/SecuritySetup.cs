namespace Ranked.Configuration.Security
{
	using Services.Security;
	using Services.Security.Interfaces;


	public static class SecuritySetup
	{
		/// <summary>
		/// Adds security related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSecurityServices(this IServiceCollection services)
		{
			services.AddTransient<ISecurityService, SecurityService>();

			return services;
		}
	}
}
