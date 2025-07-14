using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors
{
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class UserDA : IUserDA
	{
		private readonly RankedContext context;


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
			var exists = await context.Users.AnyAsync(user => user.Identifier == item);

			if (exists)
				return false;

			var entry = new User
			{
				Identifier = item,
			};

			context.Users.Add(entry);

			await context.SaveChangesAsync();

			return true;
		}

		IQueryable<string> IRead<string>.Read()
			=> context.Users
				.AsNoTracking()
				.Select(user => user.Identifier);
	}
}
