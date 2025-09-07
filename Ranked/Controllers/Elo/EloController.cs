using IOData.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers.Elo
{
	using Data.Elo.DTOs;
	using Data.Elo.Requests;
	using Data.Elo.Responses;
	using Data.Elo.Status;
	using DataAccessors.Elo.Interfaces;
	using Providers.Authorization.Policy;
	using Services.Elo.Interfaces;


	/// <summary>
	/// Controller for elo related endpoints
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class EloController : ControllerBase
	{
		private readonly IEloService eloService;

		private readonly IUserEloDA userEloDA;


		/// <summary>
		/// Constructor for <see cref="EloController"/>
		/// </summary>
		/// <param name="eloService">Service responsible for elo business logic</param>
		/// <param name="userEloDA">Data accessor for the user_elo database table</param>
		public EloController(IEloService eloService, IUserEloDA userEloDA)
		{
			this.eloService = eloService;
			this.userEloDA = userEloDA;
		}


		/// <summary>
		/// Performs an elo update for a 1v1 match between two players
		/// </summary>
		/// <param name="request">The request object containing match data</param>
		/// <returns>A <see cref="Task{TResult}"/> with a <see cref="Result{TError, TSuccess}"/> containing either a <see cref="_1v1Status"/> error or a <see cref="_1v1Response"/> result</returns>
		[HttpPost("1v1")]
		[Authorize(Policy = Policies.Elo.WRITE_ELO)]
		public Task<Result<_1v1Status, _1v1Response>> _1v1(_1v1Request request)
			=> eloService._1v1(request);

		/// <summary>
		/// Retrieves a collection of users with their associated elos
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of <see cref="UserEloDTO"/> representing user elo data</returns>
		[HttpGet]
		[Authorize(Policy = Policies.Elo.READ_ELO)]
		public IQueryable<UserEloDTO> GetUserElos()
			=> userEloDA.Read();
	}
}
