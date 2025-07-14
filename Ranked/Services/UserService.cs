namespace Ranked.Services
{
	using Data.User.Interfaces;
	using Data.User.Responses;
	using Data.User.Status;
	using DataAccessors.Interfaces;
	using Interfaces;


	/// <inheritdoc/>
	public class UserService : IUserService
	{
		private readonly IUserDA userDA;


		public UserService(IUserDA userDA)
		{
			this.userDA = userDA;
		}


		async Task<CreateUserResponse> IUserService.Create(ICreateUserRequest request)
		{
			var create = await userDA.Create(request.User);

			return new CreateUserResponse(create ? CreateUserStatus.SUCCESS : CreateUserStatus.USER_ALREADY_EXISTS);
		}
	}
}
