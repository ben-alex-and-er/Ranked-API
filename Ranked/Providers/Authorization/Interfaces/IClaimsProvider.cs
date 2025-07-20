using System.Security.Claims;


namespace Ranked.Providers.Authorization.Interfaces
{
	/// <summary>
	/// Provider for claims
	/// </summary>
	public interface IClaimsProvider
	{
		/// <summary>
		/// Retrieves a collection of claims for a role
		/// </summary>
		/// <param name="role">The role to get the claims for</param>
		/// <returns>A collection of claims</returns>
		IEnumerable<Claim> GetClaims(string role);
	}
}
