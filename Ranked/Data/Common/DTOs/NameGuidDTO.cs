namespace Ranked.Data.Common.DTOs
{
	/// <summary>
	/// DTO containing a name and a guid
	/// </summary>
	public class NameGuidDTO
	{
		/// <summary>
		/// Name of the item
		/// </summary>
		public required string Name { get; set; }

		/// <summary>
		/// Guid of the item
		/// </summary>
		public required Guid Guid { get; set; }


		public override bool Equals(object? obj)
		{
			if (obj is not NameGuidDTO other)
				return false;

			return other.Name == Name && other.Guid == Guid;
		}

		public override int GetHashCode()
			=> HashCode.Combine(Name, Guid);
	}
}
