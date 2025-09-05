namespace Ranked.Data.Security.Request.Interfaces
{
	/// <summary>
	/// Request for getting a policy bearer token
	/// </summary>
	public interface IPolicyRequest
	{
		/// <summary>
		/// Role subject
		/// </summary>
		public string Subject { get; }

		/// <summary>
		/// Role password
		/// </summary>
		public string Password { get; }
	}
}
