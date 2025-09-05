namespace Ranked.Data.Elo.Requests
{
	/// <summary>
	/// Request for getting user elos for a specific application
	/// </summary>
	public class GetUserElosRequest
	{
		/// <summary>
		/// Application Guid
		/// </summary>
		public Guid Application { get; set; }
	}
}
