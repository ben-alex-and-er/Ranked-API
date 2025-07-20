using Database.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Ranked.Configuration.Database
{
	using Models;


	public static class DatabaseSetup
	{
		/// <summary>
		/// Adds database context for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
		{
			services.AddSingleton<MySQLConnection>();

			services.AddDbContext<RankedContext>((serviceProvider, options) =>
			{
				var connectionString = serviceProvider.GetRequiredService<MySQLConnection>();

				options.UseMySql(connectionString.ToString(), ServerVersion.AutoDetect(connectionString.ToString()));
			});


			return services;
		}
	}
}
