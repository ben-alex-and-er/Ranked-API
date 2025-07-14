using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors
{
	using Data.Elo.DTOs;
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class UserEloDA : IUserEloDA
	{
		private readonly RankedContext context;


		private DbSet<User> Users
			=> context.Users;

		private DbSet<UserElo> UserElos
			=> context.UserElos;


		/// <summary>
		/// Constructor for <see cref="UserEloDA"/>
		/// </summary>
		/// <param name="context">Database Context</param>
		public UserEloDA(RankedContext context)
		{
			this.context = context;
		}


		async Task<bool> ICreate<UserEloDTO>.Create(UserEloDTO item)
		{
			var eloExists = await UserElos
				.AnyAsync(userElo => userElo.User.Identifier == item.User);

			if (eloExists)
				return false;

			var userEntry = await Users
				.FirstOrDefaultAsync(user => user.Identifier == item.User);
			
			if (userEntry == null)
				return false;

			var entry = new UserElo
			{
				User = userEntry,
				Elo = item.Elo
			};

			UserElos.Add(entry);

			await context.SaveChangesAsync();

			return true;
		}

		IQueryable<UserEloDTO> IRead<UserEloDTO>.Read()
			=> UserElos
				.AsNoTracking()
				.Select(userElo => new UserEloDTO
				{
					User = userElo.User.Identifier,
					Elo = userElo.Elo
				});

		async Task<bool> IUpdate<string, uint>.Update(string identifier, uint update)
		{
			var entry = await UserElos
				.FirstOrDefaultAsync(userElo => userElo.User.Identifier == identifier);

			if (entry == null)
				return false;

			entry.Elo = update;

			await context.SaveChangesAsync();

			return true;
		}
	}
}
