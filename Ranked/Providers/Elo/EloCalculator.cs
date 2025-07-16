namespace Ranked.Providers.Elo
{
	using Data.Elo.DTOs;


	/// <summary>
	/// Calculator for elo
	/// </summary>
	public static class EloCalculator
	{
		private const uint K = 32;


		/// <summary>
		/// Calcultates new elos based on existing elos for a winner and a loser
		/// </summary>
		/// <param name="winner"></param>
		/// <param name="loser"></param>
		/// <returns></returns>
		public static (uint, uint) Calculate1V1(uint winner, uint loser)
		{
			var expectedB = 1 / (1 + Math.Pow(10, ((double)winner - loser) / 400));
			var expectedA = 1 - expectedB;

			var newWinner = winner + K * (1 - expectedA);

			if (newWinner < 0)
				newWinner = 0;

			var newLoser = Math.Round(loser + K * -expectedB);
			
			if (newLoser < 0)
				newLoser = 0;

			return ((uint)Math.Round(newWinner), (uint)Math.Round(newLoser));
		}

		/// <summary>
		/// Calculates elos for winners and losers in teams
		/// </summary>
		/// <param name="winningTeam"></param>
		/// <param name="losingTeam"></param>
		/// <returns></returns>
		public static (List<UserEloDTO>, List<UserEloDTO>) CalculateElos(
			IEnumerable<UserEloDTO> winningTeam,
			IEnumerable<UserEloDTO> losingTeam)
		{
			var averageWin = (uint)(winningTeam.Sum(x => x.Elo) / winningTeam.Count());
			var averageLose = (uint)(losingTeam.Sum(x => x.Elo) / losingTeam.Count());

			var (newWinnerAverage, newLoserAverage) = Calculate1V1(averageWin, averageLose);

			var deltaWin = newWinnerAverage - averageWin;
			var deltaLose = newLoserAverage - averageLose;

			var newWinning = AddDeltas(winningTeam, deltaWin);
			var newLosing = AddDeltas(losingTeam, deltaLose);

			return (newWinning, newLosing);
		}


		private static List<UserEloDTO> AddDeltas(IEnumerable<UserEloDTO> userElos, uint delta)
		{
			var newElos = new List<UserEloDTO>();

			foreach (var userElo in userElos)
			{
				newElos.Add(new UserEloDTO
				{
					User = userElo.User,
					Elo = userElo.Elo + delta
				});
			}

			return newElos;
		}
	}
}
