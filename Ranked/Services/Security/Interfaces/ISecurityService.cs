using Microsoft.AspNetCore.Mvc;


namespace Ranked.Services.Security.Interfaces
{
	using Data.Security.Request.Interfaces;


	/// <summary>
	/// Service responsible for security business logic
	/// </summary>
	public interface ISecurityService
	{
		/// <summary>
		/// Gets the bearer token for the policy of the user.
		/// Is used to authorize the user for other endpoints
		/// </summary>
		/// <param name="request">The Policy Request</param>
		/// <returns>The Encoded JWT Token</returns>
		Task<IActionResult> GetPolicyToken(IPolicyRequest request);
	}
}
