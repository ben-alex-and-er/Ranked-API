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
		public Guid Application { get; }


		/// <summary>
		/// Constructor for <see cref="GetUserElosRequest"/>
		/// </summary>
		/// <param name="application">Application Guid</param>
		public GetUserElosRequest(Guid application)
		{
			Application = application;
		}
	}
}
