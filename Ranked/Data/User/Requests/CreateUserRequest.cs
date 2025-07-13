namespace Ranked.Data.User.Requests
{
	using Interfaces;


	public class CreateUserRequest : ICreateUserRequest
	{
		public string User { get; }


		public CreateUserRequest(string user)
		{
			User = user;
		}
	}
}
