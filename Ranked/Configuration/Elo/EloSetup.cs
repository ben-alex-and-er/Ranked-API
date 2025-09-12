namespace Ranked.Configuration.Elo
{
	using DataAccessors.Elo;
	using DataAccessors.Elo.Interfaces;
	using Services.Elo;
	using Services.Elo.Interfaces;


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

			services.AddTransient<IUserApplicationEloDA, UserApplicationEloDA>();

			return services;
		}
	}
}
