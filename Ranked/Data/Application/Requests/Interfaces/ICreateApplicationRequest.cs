namespace Ranked.Data.Application.Requests.Interfaces
{
	/// <summary>
	/// Request for creating a new application
	/// </summary>
	public interface ICreateApplicationRequest
	{
		/// <summary>
		/// New application name
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// New application guid
		/// </summary>
		public Guid Guid { get; }
	}
}
