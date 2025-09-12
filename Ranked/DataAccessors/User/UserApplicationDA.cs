using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors.User
{
	using Data.User.DTOs;
	using Data.User.Interfaces;
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class UserApplicationDA : IUserApplicationDA
	{
		private readonly RankedContext context;


		private DbSet<Application> Applications
			=> context.Applications;

		private DbSet<User> Users
			=> context.Users;

		private DbSet<UserApplication> UserApplications
			=> context.UserApplications;


		/// <summary>
		/// Constructor for <see cref="UserApplicationDA"/>
		/// </summary>
		/// <param name="context">Database Context</param>
		public UserApplicationDA(RankedContext context)
		{
			this.context = context;
		}


		async Task<bool> ICreate<ICreateUserRequest>.Create(ICreateUserRequest item)
		{
			var userEntry = await Users
				.FirstOrDefaultAsync(user => user.Identifier == item.User);

			if (userEntry == null)
				return false;


			var applicationEntry = await Applications
				.FirstOrDefaultAsync(app => app.Guid == item.Application);

			if (applicationEntry == null)
				return false;


			var exists = await UserApplications
				.Where(userApp => userApp.User.Identifier == item.User)
				.Where(userApp => userApp.User.Identifier == item.User)
				.AnyAsync();

			if (exists)
				return false;


			UserApplications.Add(new UserApplication
			{
				User = userEntry,
				Application = applicationEntry
			});

			await context.SaveChangesAsync();

			return true;
		}

		IQueryable<UserApplicationDTO> IRead<UserApplicationDTO>.Read()
			=> UserApplications
				.AsNoTracking()
				.Select(x => new UserApplicationDTO
				{
					User = x.User.Identifier,
					Application = x.Application.Guid
				});
	}
}
