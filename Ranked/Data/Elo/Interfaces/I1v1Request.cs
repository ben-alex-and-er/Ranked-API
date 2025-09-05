namespace Ranked.Data.Elo.Interfaces
{
	using User.DTOs;


	/// <summary>
	/// Request containing match data for a 1v1 between two players
	/// </summary>
	public interface I1v1Request
	{
		/// <summary>
		/// The user application of the winner
		/// </summary>
		public UserApplicationDTO Winner { get; }

		/// <summary>
		/// The user application of the loser
		/// </summary>
		public UserApplicationDTO Loser { get; }
	}
}
