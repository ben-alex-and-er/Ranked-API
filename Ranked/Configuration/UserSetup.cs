namespace Ranked.Configuration
{
	using DataAccessors;
	using DataAccessors.Interfaces;
	using Services;
	using Services.Interfaces;


	public static class UserSetup
	{
		/// <summary>
		/// Adds user related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddUserServices(this IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();

			services.AddTransient<IUserDA, UserDA>();

			return services;
		}
	}
}
