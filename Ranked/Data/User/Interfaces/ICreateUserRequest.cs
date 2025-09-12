namespace Ranked.Data.User.Interfaces
{
	/// <summary>
	/// Request for creating a new user
	/// </summary>
	public interface ICreateUserRequest
	{
		/// <summary>
		/// New User Identifier
		/// </summary>
		public string User { get; }

		/// <summary>
		/// Application for the user
		/// </summary>
		public Guid Application { get; }
	}
}
