using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors.Elo
{
	using Data.Elo.DTOs;
	using Data.User.DTOs;
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class UserApplicationEloDA : IUserApplicationEloDA
	{
		private readonly RankedContext context;


		private DbSet<UserApplication> UserApplications
			=> context.UserApplications;

		private DbSet<UserApplicationElo> UserApplicationElos
			=> context.UserApplicationElos;


		/// <summary>
		/// Constructor for <see cref="UserApplicationEloDA"/>
		/// </summary>
		/// <param name="context">Database Context</param>
		public UserApplicationEloDA(RankedContext context)
		{
			this.context = context;
		}


		async Task<bool> ICreate<UserApplicationEloDTO>.Create(UserApplicationEloDTO item)
		{
			var eloExists = await UserApplicationElos
				.Where(userAppElo => userAppElo.UserApplication.User.Identifier == item.UserApplication.User)
				.Where(userAppElo => userAppElo.UserApplication.Application.Guid == item.UserApplication.Application)
				.AnyAsync();

			if (eloExists)
				return false;

			var userAppEntry = await UserApplications
				.Where(userApp => userApp.User.Identifier == item.UserApplication.User)
				.Where(userApp => userApp.Application.Guid == item.UserApplication.Application)
				.FirstOrDefaultAsync();
			
			if (userAppEntry == null)
				return false;

			var entry = new UserApplicationElo
			{
				UserApplication = userAppEntry,
				Elo = item.Elo
			};

			UserApplicationElos.Add(entry);

			await context.SaveChangesAsync();

			return true;
		}

		IQueryable<UserApplicationEloDTO> IRead<UserApplicationEloDTO>.Read()
			=> UserApplicationElos
				.AsNoTracking()
				.Select(userAppElo => new UserApplicationEloDTO
				{
					UserApplication = new UserApplicationDTO
					{
						User = userAppElo.UserApplication.User.Identifier,
						Application = userAppElo.UserApplication.Application.Guid
					},
					Elo = userAppElo.Elo
				});

		async Task<bool> IUpdate<UserApplicationDTO, uint>.Update(UserApplicationDTO identifier, uint update)
		{
			var entry = await UserApplicationElos
				.Where(userAppElo => userAppElo.UserApplication.User.Identifier == identifier.User)
				.Where(userAppElo => userAppElo.UserApplication.Application.Guid == identifier.Application)
				.FirstOrDefaultAsync();

			if (entry == null)
				return false;

			entry.Elo = update;

			await context.SaveChangesAsync();

			return true;
		}
	}
}
