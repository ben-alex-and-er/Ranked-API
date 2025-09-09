namespace Ranked.Data.Authorization.DTOs
{
	/// <summary>
	/// Data Transfer Object containing a user identifier and their associated elo
	/// </summary>
	public class ClaimDTO
	{
		/// <summary>
		/// Claim Type
		/// </summary>
		public required string Type { get; set; }

		/// <summary>
		/// Claim Value
		/// </summary>
		public required uint Value { get; set; }


		public override bool Equals(object? obj)
		{
			if (obj is not ClaimDTO other)
				return false;

			return other.Type == Type && other.Value == Value;
		}

		public override int GetHashCode()
			=> HashCode.Combine(Type, Value);
	}
}
