namespace Ranked.Data.Elo.Requests
{
	using Interfaces;


	/// <inheritdoc/>
	public class _1v1Request : I1v1Request
	{
		/// <inheritdoc/>
		public string Winner { get; }

		/// <inheritdoc/>
		public string Loser { get; }


		/// <summary>
		/// Constructor for <see cref="_1v1Request"/>
		/// </summary>
		/// <param name="winner">The user identifier of the winner</param>
		/// <param name="loser">The user identifier of the loser</param>
		public _1v1Request(string winner, string loser)
		{
			Winner = winner;
			Loser = loser;
		}
	}
}
