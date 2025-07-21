namespace Ranked.Data.Elo.Status
{
	/// <summary>
	/// Status codes for performing a 1v1 match request
	/// </summary>
	public enum _1v1Status
	{
		/// <summary>
		/// Indicates the 1v1 request completed successfully
		/// </summary>
		SUCCESS = 0,

		/// <summary>
		/// Indicates the 1v1 request failed
		/// due to the winner's user identifier not being found
		/// </summary>
		WINNER_IDENTIFIER_NOT_FOUND = 1,

		/// <summary>
		/// Indicates the 1v1 request failed
		/// due to the loser's user identifier not being found
		/// </summary>
		LOSER_IDENTIFIER_NOT_FOUND = 2,

		/// <summary>
		/// Indicates the 1v1 request failed
		/// due to the winner's elo failing to update
		/// </summary>
		WINNER_ELO_UPDATE_FAILED = 3,

		/// <summary>
		/// Indicates the 1v1 request failed
		/// due to the loser's elo failing to update
		/// </summary>
		LOSER_ELO_UPDATE_FAILED = 4,
	}
}
