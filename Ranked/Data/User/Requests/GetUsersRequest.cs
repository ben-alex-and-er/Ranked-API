namespace Ranked.Data.User.Requests
{
	/// <summary>
	/// Request for getting all users on a specific application
	/// </summary>
	public class GetUsersRequest
	{
		/// <summary>
		/// Application Guid
		/// </summary>
		public Guid Application { get; set; }
	}
}
