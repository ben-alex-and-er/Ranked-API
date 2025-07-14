namespace Ranked.Configuration
{
	using DataAccessors;
	using DataAccessors.Interfaces;
	using Services;
	using Services.Interfaces;


	public static class EloSetup
	{
		/// <summary>
		/// Adds elo related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddEloServices(this IServiceCollection services)
		{
			services.AddTransient<IEloService, EloService>();

			services.AddTransient<IUserEloDA, UserEloDA>();

			return services;
		}
	}
}
