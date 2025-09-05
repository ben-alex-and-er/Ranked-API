using DataAccessors.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ranked.DataAccessors.Application
{
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
