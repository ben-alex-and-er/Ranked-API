using IOData.Output;


namespace Ranked.Services.Elo
{
	using Data.Elo.DTOs;
	using Data.Elo.Interfaces;
	using Data.Elo.Responses;
	using Data.Elo.Status;
	using DataAccessors.Elo.Extensions;
	using DataAccessors.Elo.Interfaces;
	using Interfaces;
	using Providers.Elo;


	/// <inheritdoc/>
	public class EloService : IEloService
	{
		private readonly IUserApplicationEloDA userApplicationEloDA;


		/// <summary>
		/// Constructor for <see cref="EloService"/>
		/// </summary>
		/// <param name="userApplicationEloDA">Data accessor for the user_application_elo database table</param>
		public EloService(IUserApplicationEloDA userApplicationEloDA)
		{
			this.userApplicationEloDA = userApplicationEloDA;
		}


		async Task<Result<_1v1Status, _1v1Response>> IEloService._1v1(I1v1Request request)
		{
			var winnerElo = await userApplicationEloDA.ReadFirst(request.Winner);

			if (winnerElo == null)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.WINNER_IDENTIFIER_NOT_FOUND);

			var loserElo = await userApplicationEloDA.ReadFirst(request.Loser);

			if (loserElo == null)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.LOSER_IDENTIFIER_NOT_FOUND);


			var (newWin, newLose) = EloCalculator.Calculate1V1(winnerElo.Elo, loserElo.Elo);


			var updateWinner = await userApplicationEloDA.Update(request.Winner, newWin);

			if (!updateWinner)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.WINNER_ELO_UPDATE_FAILED);

			var updateLoser = await userApplicationEloDA.Update(request.Loser, newLose);

			if (!updateLoser)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.LOSER_ELO_UPDATE_FAILED);


			var response = new _1v1Response(
				new UserApplicationEloDTO
				{
					UserApplication = request.Winner,
					Elo = newWin
				},
				new UserApplicationEloDTO
				{
					UserApplication = request.Loser,
					Elo = newLose
				});

			return new Result<_1v1Status, _1v1Response>(_1v1Status.SUCCESS, response);
		}
	}
}
