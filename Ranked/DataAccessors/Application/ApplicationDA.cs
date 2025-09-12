using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors.Application
{
	using Data.Application.Requests.Interfaces;
	using Data.Common.DTOs;
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class ApplicationDA : IApplicationDA
	{
		private readonly RankedContext context;


		private DbSet<Application> Applications
			=> context.Applications;


		/// <summary>
		/// Constructor for <see cref="ApplicationDA"/>
		/// </summary>
		/// <param name="context">Database Context</param>
		public ApplicationDA(RankedContext context)
		{
			this.context = context;
		}


		async Task<bool> ICreate<ICreateApplicationRequest>.Create(ICreateApplicationRequest item)
		{
			var nameExists = await Applications
				.AsNoTracking()
				.AnyAsync(app => app.Name == item.Name);

			if (nameExists)
				return false;

			var guidExists = await Applications
				.AsNoTracking()
				.AnyAsync(app => app.Guid == item.Guid);

			if (guidExists)
				return false;


			Applications.Add(new Application
			{
				Name = item.Name,
				Guid = item.Guid,
			});


			await context.SaveChangesAsync();

			return true;
		}

		IQueryable<NameGuidDTO> IRead<NameGuidDTO>.Read()
			=> Applications
				.AsNoTracking()
				.Select(app => new NameGuidDTO
				{
					Name = app.Name,
					Guid = app.Guid
				});
	}
}
