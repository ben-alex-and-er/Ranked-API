namespace Ranked.Data.Elo.DTOs
{
	/// <summary>
	/// Data Transfer Object containing a user identifier and their associated elo
	/// </summary>
	public class UserEloDTO
	{
		/// <summary>
		/// User Identifier
		/// </summary>
		public required string User {  get; set; }

		/// <summary>
		/// User Elo
		/// </summary>
		public required uint Elo { get; set; }


		public override bool Equals(object? obj)
		{
			if (obj is not UserEloDTO other)
				return false;

			return other.User == User && other.Elo == Elo;
		}

		public override int GetHashCode()
			=> HashCode.Combine(User, Elo);
	}
}
