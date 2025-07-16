using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers.User
{
	using Data.User.Requests;
	using Data.User.Responses;
	using DataAccessors.User.Interfaces;
	using Services.User.Interfaces;


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
		public Task<CreateUserResponse> CreateUser(CreateUserRequest request)
			=> userService.Create(request);

		/// <summary>
		/// Retrieves a list of user identifiers
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of strings representing user identifiers.</returns>
		[HttpGet]
		public IQueryable<string> GetUsers()
			=> userDA.Read();
	}
}
