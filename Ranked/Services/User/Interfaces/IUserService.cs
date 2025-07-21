namespace Ranked.Services.User.Interfaces
{
	using Data.User.Interfaces;
	using Data.User.Responses;


	/// <summary>
	/// Service responsible for user business logic
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Creates a new user
		/// </summary>
		/// <param name="request">The request object containing user creation data.</param>
		/// <returns>A <see cref="Task{TResult}"/> with a <see cref="CreateUserResponse"/> result</returns>
		Task<CreateUserResponse> Create(ICreateUserRequest request);
	}
}
