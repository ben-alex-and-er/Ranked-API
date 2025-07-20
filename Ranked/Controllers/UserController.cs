using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers
{
	using Data.User.Requests;
	using Data.User.Responses;
	using DataAccessors.Interfaces;
	using Providers.Authorization.Policy;
	using Services.Interfaces;


	/// <summary>
	/// Controller for user related endpoints
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;

		private readonly IUserDA userDA;


		/// <summary>
		/// Constructor for <see cref="UserController"/>
		/// </summary>
		/// <param name="userService">Service responsible for user business logic</param>
		/// <param name="userDA">Data accessor for the user database table</param>
		public UserController(IUserService userService, IUserDA userDA)
		{
			this.userService = userService;
			this.userDA = userDA;
		}

		/// <summary>
		/// Creates a new user
		/// </summary>
		/// <param name="request">The request object containing user creation data</param>
		/// <returns>A <see cref="Task{TResult}"/> with a <see cref="CreateUserResponse"/> result</returns>
		[HttpPost]
		[Authorize(Policy = Policies.User.WRITE)]
		public Task<CreateUserResponse> CreateUser(CreateUserRequest request)
			=> userService.Create(request);

		/// <summary>
		/// Retrieves a list of user identifiers
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of strings representing user identifiers.</returns>
		[HttpGet]
		[Authorize(Policy = Policies.User.READ)]
		public IQueryable<string> GetUsers()
			=> userDA.Read();
	}
}
