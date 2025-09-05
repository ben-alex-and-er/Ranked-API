using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers.Application
{
	using Data.Application.Requests;
	using Data.Common.DTOs;
	using DataAccessors.Application.Interfaces;
	using Providers.Authorization.Policy;


	/// <summary>
	/// Controller for application related endpoints
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class ApplicationController : ControllerBase
	{
		private readonly IApplicationDA applicationDA;


		/// <summary>
		/// Constructor for <see cref="ApplicationController"/>
		/// </summary>
		/// <param name="applicationDA">Data accessor for the application database table</param>
		public ApplicationController(IApplicationDA applicationDA)
		{
			this.applicationDA = applicationDA;
		}


		/// <summary>
		/// Creates a new application
		/// </summary>
		/// <param name="request">The request object containing application data</param>
		/// <returns>A <see cref="Task{TResult}"/> with a <see cref="bool"/> determining whether the application was created</returns>
		[HttpPost]
		[Authorize(Policy = Policies.Application.WRITE)]
		public Task<bool> CreateApplication(CreateApplicationRequest request)
			=> applicationDA.Create(request);

		/// <summary>
		/// Retrieves a collection of applications
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of <see cref="NameGuidDTO"/> representing application data</returns>
		[HttpGet]
		[Authorize(Policy = Policies.Application.READ)]
		public IQueryable<NameGuidDTO> GetApplications()
			=> applicationDA.Read();
	}
}
