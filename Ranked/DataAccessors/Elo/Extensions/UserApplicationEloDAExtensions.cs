using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors.Elo.Extensions
{
	using Data.Elo;
	using Data.Elo.DTOs;
	using Data.User.DTOs;
	using Data.User.Interfaces;
	using Elo.Interfaces;


	/// <summary>
	/// Extension methods for <see cref="IUserApplicationEloDA"/>
	/// </summary>
	public static class UserApplicationEloDAExtensions
	{
		/// <summary>
		/// Creates a new entry in the database with the initial elo
		/// </summary>
		/// <param name="userApplicationEloDA"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public static Task<bool> Create(this IUserApplicationEloDA userApplicationEloDA, ICreateUserRequest item)
			=> userApplicationEloDA.Create(new UserApplicationEloDTO
			{
				UserApplication = new UserApplicationDTO
				{
					User = item.User,
					Application = item.Application
				},
				Elo = EloConsts.INITIAL_ELO
			});

		/// <summary>
		/// Reads the first entry for a user application
		/// </summary>
		/// <param name="userApplicationEloDA">DataAccessor to use</param>
		/// <param name="identifier">User Application to query</param>
		/// <returns></returns>
		public static Task<UserApplicationEloDTO?> ReadFirst(
			this IUserApplicationEloDA userApplicationEloDA,
			UserApplicationDTO identifier)
			=> userApplicationEloDA.Read()
				.Where(userAppElo => userAppElo.UserApplication.User == identifier.User)
				.Where(userAppElo => userAppElo.UserApplication.Application == identifier.Application)
				.FirstOrDefaultAsync();
	}
}
