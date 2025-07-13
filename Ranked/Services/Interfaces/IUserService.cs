namespace Ranked.Services.Interfaces
{
	using Data.User.Interfaces;
	using Data.User.Responses;


	public interface IUserService
	{
		Task<CreateUserResponse> Create(ICreateUserRequest request);
	}
}
