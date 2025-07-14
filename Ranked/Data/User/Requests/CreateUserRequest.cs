namespace Ranked.Data.User.Requests
{
	using Interfaces;


	/// <inheritdoc/>
	public class CreateUserRequest : ICreateUserRequest
	{
		/// <inheritdoc/>
		public string User { get; }


		/// <summary>
		/// Constructor for <see cref="CreateUserRequest"/>
		/// </summary>
		/// <param name="user">New User Identfier</param>
		public CreateUserRequest(string user)
		{
			User = user;
		}
	}
}
