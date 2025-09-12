namespace Ranked.Data.User.Requests
{
	using Interfaces;


	/// <inheritdoc/>
	public class CreateUserRequest : ICreateUserRequest
	{
		/// <inheritdoc/>
		public string User { get; }

		/// <inheritdoc/>
		public Guid Application { get; }


		/// <summary>
		/// Constructor for <see cref="CreateUserRequest"/>
		/// </summary>
		/// <param name="user">New User Identfier</param>
		/// <param name="application">Application for the user</param>
		public CreateUserRequest(string user, Guid application)
		{
			User = user;
			Application = application;
		}
	}
}
