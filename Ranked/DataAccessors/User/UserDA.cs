using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors.User
{
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class UserDA : IUserDA
	{
		private readonly RankedContext context;


		private DbSet<User> Users
			=> context.Users;


		/// <summary>
		/// Constructor for <see cref="UserDA"/>
		/// </summary>
		/// <param name="context">Database Context</param>
		public UserDA(RankedContext context)
		{
			this.context = context;
		}


		async Task<bool> ICreate<string>.Create(string item)
		{
			var exists = await Users.AnyAsync(user => user.Identifier == item);

			if (exists)
				return false;

			var entry = new User
			{
				Identifier = item,
			};

			Users.Add(entry);

			await context.SaveChangesAsync();

			return true;
		}

		IQueryable<string> IRead<string>.Read()
			=> Users
				.AsNoTracking()
				.Select(user => user.Identifier);
	}
}
