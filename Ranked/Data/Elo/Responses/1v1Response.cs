namespace Ranked.Data.Elo.Responses
{
	using DTOs;


	/// <summary>
	/// Response from a 1v1 match request containing the winner and loser's user application and elos
	/// </summary>
	public class _1v1Response
	{
		/// <summary>
		/// The user application and elo of the winner
		/// </summary>
		public UserApplicationEloDTO Winner { get; }

		/// <summary>
		/// The user application and elo of the loser
		/// </summary>
		public UserApplicationEloDTO Loser { get; }


		/// <summary>
		/// Constructor for <see cref="_1v1Response"/>
		/// </summary>
		/// <param name="winner">The user application and elo of the winner</param>
		/// <param name="loser">The user application and elo of the loser</param>
		public _1v1Response(UserApplicationEloDTO winner, UserApplicationEloDTO loser)
		{
			Winner = winner;
			Loser = loser;
		}
	}
}
