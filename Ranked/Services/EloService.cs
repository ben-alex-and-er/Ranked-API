using IOData.Output;
using Microsoft.EntityFrameworkCore;


namespace Ranked.Services
{
	using Data.Elo.DTOs;
	using Data.Elo.Interfaces;
	using Data.Elo.Responses;
	using Data.Elo.Status;
	using DataAccessors.Interfaces;
	using Interfaces;
	using Providers;


	/// <inheritdoc/>
	public class EloService : IEloService
	{
		private readonly IUserEloDA userEloDA;


		/// <summary>
		/// Constructor for <see cref="EloService"/>
		/// </summary>
		/// <param name="userEloDA">Data accessor for the user_elo database table</param>
		public EloService(IUserEloDA userEloDA)
		{
			this.userEloDA = userEloDA;
		}


		async Task<Result<_1v1Status, _1v1Response>> IEloService._1v1(I1v1Request request)
		{
			var winnerElo = await userEloDA.Read()
				.FirstOrDefaultAsync(userElo => userElo.User == request.Winner);

			if (winnerElo == null)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.WINNER_IDENTIFIER_NOT_FOUND);

			var loserElo = await userEloDA.Read()
				.FirstOrDefaultAsync(userElo => userElo.User == request.Loser);

			if (loserElo == null)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.LOSER_IDENTIFIER_NOT_FOUND);


			var (newWin, newLose) = EloCalculator.Calculate1V1(winnerElo.Elo, loserElo.Elo);


			var updateWinner = await userEloDA.Update(request.Winner, newWin);

			if (!updateWinner)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.WINNER_ELO_UPDATE_FAILED);

			var updateLoser = await userEloDA.Update(request.Loser, newLose);

			if (!updateLoser)
				return new Result<_1v1Status, _1v1Response>(_1v1Status.LOSER_ELO_UPDATE_FAILED);


			var response = new _1v1Response(
				new UserEloDTO
				{
					User = request.Winner,
					Elo = newWin
				},
				new UserEloDTO
				{
					User = request.Loser,
					Elo = newLose
				});

			return new Result<_1v1Status, _1v1Response>(_1v1Status.SUCCESS, response);
		}
	}
}
