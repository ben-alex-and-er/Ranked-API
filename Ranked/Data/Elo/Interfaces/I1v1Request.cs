namespace Ranked.Data.Elo.Interfaces
{
	/// <summary>
	/// Request containing match data for a 1v1 between two players
	/// </summary>
	public interface I1v1Request
	{
		/// <summary>
		/// The user identifier of the winner
		/// </summary>
		public string Winner { get; }

		/// <summary>
		/// The user identifier of the loser
		/// </summary>
		public string Loser { get; }
	}
}
