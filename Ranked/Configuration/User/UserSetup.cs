namespace Ranked.Configuration.User
{
	using DataAccessors.User;
	using DataAccessors.User.Interfaces;
	using Services.User;
	using Services.User.Interfaces;


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
			services.AddTransient<IUserApplicationDA, UserApplicationDA>();

			return services;
		}
	}
}
