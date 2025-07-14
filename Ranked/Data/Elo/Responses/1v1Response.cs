namespace Ranked.Data.Elo.Responses
{
	using DTOs;


	/// <summary>
	/// Response from a 1v1 match request containing the winner and loser's user identfiers and elos
	/// </summary>
	public class _1v1Response
	{
		/// <summary>
		/// The user identifier and elo of the winner
		/// </summary>
		public UserEloDTO Winner { get; }

		/// <summary>
		/// The user identifier and elo of the loser
		/// </summary>
		public UserEloDTO Loser { get; }


		/// <summary>
		/// Constructor for <see cref="_1v1Response"/>
		/// </summary>
		/// <param name="winner">The user identifier and elo of the winner</param>
		/// <param name="loser">The user identifier and elo of the loser</param>
		public _1v1Response(UserEloDTO winner, UserEloDTO loser)
		{
			Winner = winner;
			Loser = loser;
		}
	}
}
