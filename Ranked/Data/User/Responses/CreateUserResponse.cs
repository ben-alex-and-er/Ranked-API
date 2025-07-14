namespace Ranked.Data.User.Responses
{
	using Status;


	/// <summary>
	/// Reponse from a create user request 
	/// </summary>
	public class CreateUserResponse
	{
		/// <summary>
		/// Status code of the operation
		/// </summary>
		public CreateUserStatus Status { get; }


		/// <summary>
		/// Constructor for <see cref="CreateUserResponse"/>
		/// </summary>
		/// <param name="status">Status code of the operation</param>
		public CreateUserResponse(CreateUserStatus status)
		{
			Status = status;
		}
	}
}
