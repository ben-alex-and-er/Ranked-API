namespace Ranked.Data.Elo.DTOs
{
	using User.DTOs;


	/// <summary>
	/// Data Transfer Object containing a user application and their associated elo
	/// </summary>
	public class UserApplicationEloDTO
	{
		/// <summary>
		/// User Application combination
		/// </summary>
		public UserApplicationDTO UserApplication { get; set; }

		/// <summary>
		/// Elo rating
		/// </summary>
		public uint Elo { get; set; }


		public override bool Equals(object? obj)
		{
			if (obj is not UserApplicationEloDTO other)
				return false;

			return other.UserApplication == UserApplication && other.Elo == Elo;
		}

		public override int GetHashCode()
			=> HashCode.Combine(UserApplication, Elo);
	}
}
