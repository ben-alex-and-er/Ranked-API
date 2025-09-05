using Microsoft.AspNetCore.Mvc;


namespace Ranked.Controllers.Security
{
	using Data.Security.Request;
	using Services.Security.Interfaces;


	/// <summary>
	/// Controller for security related endpoints
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class SecurityController : ControllerBase
	{
		private readonly ISecurityService securityService;


		public SecurityController(ISecurityService securityService)
		{
			this.securityService = securityService;
		}


		/// <summary>
		/// Gets the bearer token for the policy of the user.
		/// Is used to authorize the user for other endpoints
		/// </summary>
		/// <param name="request">The Policy Request</param>
		/// <returns>The Encoded JWT Token</returns>
		[HttpPost("bearer")]
		public Task<IActionResult> GetPolicyToken([FromBody] PolicyRequest request)
			=> securityService.GetPolicyToken(request);
	}
}
