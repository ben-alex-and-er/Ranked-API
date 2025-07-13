namespace Ranked.Data.User.Responses
{
	using Status;


	public class CreateUserResponse
	{
		public CreateUserStatus Status { get; }


		public CreateUserResponse(CreateUserStatus status)
		{
			Status = status;
		}
	}
}
