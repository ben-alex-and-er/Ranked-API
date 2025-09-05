using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers.User
{
	using Data.User.DTOs;
	using Data.User.Requests;
	using Data.User.Responses;
	using DataAccessors.User.Interfaces;
	using Providers.Authorization.Policy;
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

		private readonly IUserApplicationDA userApplicationDA;


		/// <summary>
		/// Constructor for <see cref="UserController"/>
		/// </summary>
		/// <param name="userService">Service responsible for user business logic</param>
		/// <param name="userDA">Data accessor for the user database table</param>
		/// <param name="userApplicationDA">Data accessor for the user_application database table</param>
		public UserController(
			IUserService userService,
			IUserDA userDA,
			IUserApplicationDA userApplicationDA)
		{
			this.userService = userService;
			this.userDA = userDA;
			this.userApplicationDA = userApplicationDA;
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
		/// Retrieves a collection of user identifiers
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of strings representing user identifiers.</returns>
		[HttpGet("allusers")]
		[Authorize(Policy = Policies.User.READ)]
		public IQueryable<string> GetAllUsers()
			=> userDA.Read();

		/// <summary>
		/// Retrieves a collection of user applications
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of user application combinations.</returns>
		[HttpGet("userapplications")]
		[Authorize(Policy = Policies.User.READ)]
		public IQueryable<UserApplicationDTO> GetUserApplications()
			=> userApplicationDA.Read();

		/// <summary>
		/// Retrieves a collection of user applications
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of strings representing user identifiers.</returns>
		[HttpGet("users")]
		[Authorize(Policy = Policies.User.READ)]
		public IQueryable<string> GetUsers(GetUsersRequest request)
			=> userApplicationDA.Read()
				.Where(userApp => userApp.Application == request.Application)
				.Select(userApp => userApp.User);
	}
}
