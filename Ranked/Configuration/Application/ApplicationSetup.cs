namespace Ranked.Configuration.Application
{
	using DataAccessors.Application;
	using DataAccessors.Application.Interfaces;


	public static class ApplicationSetup
	{
		/// <summary>
		/// Adds application related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddTransient<IApplicationDA, ApplicationDA>();

			return services;
		}
	}
}
