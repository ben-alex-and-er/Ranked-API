namespace Ranked.Data.Elo.DTOs
{
	/// <summary>
	/// Data Transfer Object containing a user identifier and their associated elo
	/// </summary>
	public class UserEloDTO
	{
		/// <summary>
		/// User identifier
		/// </summary>
		public required string User { get; set; }

		/// <summary>
		/// Elo rating
		/// </summary>
		public required uint Elo { get; set; }
	}
}
