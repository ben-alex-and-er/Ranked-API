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
		/// <param name="winner">Winner's elo</param>
		/// <param name="loser">Loser's elo</param>
		/// <returns></returns>
		public static (uint, uint) Calculate1V1(uint winner, uint loser, uint maxEloChange = K)
		{
			var expectedLoserToLose = 1 / (1 + Math.Pow(10, ((double)winner - loser) / 400));
			var expectedWinnerToWin = 1 - expectedLoserToLose;

			var newWinnerElo = Math.Round(winner + maxEloChange * (1 - expectedWinnerToWin));

			if (newWinnerElo < 0)
				newWinnerElo = 0;

			var newLoserElo = Math.Round(loser + maxEloChange * -expectedLoserToLose);
			
			if (newLoserElo < 0)
				newLoserElo = 0;

			return ((uint)newWinnerElo, (uint)newLoserElo);
		}

		/// <summary>
		/// Calculates elos for winners and losers in teams
		/// </summary>
		/// <param name="winningTeam">A collection of user elo pairs of the winning users</param>
		/// <param name="losingTeam">A collection of user elo pairs of the losing users</param>
		/// <returns></returns>
		public static (List<UserEloDTO>, List<UserEloDTO>) CalculateElos(
			IEnumerable<UserEloDTO> winningTeam,
			IEnumerable<UserEloDTO> losingTeam,
			uint maxEloChange = K)
		{
			if (!winningTeam.Any())
				return ([], losingTeam.ToList());

			if (!losingTeam.Any())
				return (winningTeam.ToList(), []);

			var averageWin = (uint)MathF.Round(winningTeam.Sum(x => x.Elo) / winningTeam.Count());
			var averageLose = (uint)MathF.Round(losingTeam.Sum(x => x.Elo) / losingTeam.Count());

			var (newWinnerAverage, newLoserAverage) = Calculate1V1(averageWin, averageLose, maxEloChange);

			var deltaWin = newWinnerAverage - averageWin;
			var deltaLose = newLoserAverage - averageLose;

			var newWinning = AddDeltas(winningTeam, deltaWin);
			var newLosing = AddDeltas(losingTeam, deltaLose);

			return (newWinning, newLosing);
		}

		public static (List<UserEloDTO>, List<UserEloDTO>) CalculateWeightedElos(
			IEnumerable<UserEloDTO> winningTeam,
			IEnumerable<UserEloDTO> losingTeam,
			uint maxEloChange = K)
		{
			if (!winningTeam.Any())
				return ([], losingTeam.ToList());

			if (!losingTeam.Any())
				return (winningTeam.ToList(), []);

			var biggestTeamCount = Math.Max(winningTeam.Count(), losingTeam.Count());

			var averageWin = (uint)(winningTeam.Sum(x => x.Elo) / biggestTeamCount);
			var averageLose = (uint)(losingTeam.Sum(x => x.Elo) / biggestTeamCount);

			var (newWinnerAverage, newLoserAverage) = Calculate1V1(averageWin, averageLose, maxEloChange);

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
