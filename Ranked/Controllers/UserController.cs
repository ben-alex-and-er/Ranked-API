using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers
{
	using Data.User.Requests;
	using Data.User.Responses;
	using DataAccessors.Interfaces;
	using Services.Interfaces;


	[ApiController]
	[Route("api/{controller}")]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;

		private readonly IUserDA userDA;


		public UserController(IUserService userService, IUserDA userDA)
		{
			this.userService = userService;
			this.userDA = userDA;
		}


		[HttpPost]
		public Task<CreateUserResponse> CreateUser(CreateUserRequest request)
			=> userService.Create(request);


		[HttpGet]
		public IQueryable<string> GetUsers()
			=> userDA.Read();
	}
}
