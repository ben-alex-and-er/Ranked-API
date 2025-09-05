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
		public string Name { get; set; }

		/// <summary>
		/// Guid of the item
		/// </summary>
		public Guid Guid { get; set; }
	}
}
