using System.Security.Claims;


namespace Ranked.Providers.Authorization
{
	using Interfaces;


	/// <inheritdoc/>
	[Obsolete("This should be using the Database")]
	public class ClaimsProvider : IClaimsProvider
	{
		private static readonly Dictionary<string, List<Claim>> roles = new()
		{
			{ "user", new List<Claim>(){ new(ClaimTypes.Role, "userRole") } }
		};


		IEnumerable<Claim> IClaimsProvider.GetClaims(string role)
			=> roles.TryGetValue(role, out var claims)
				? claims
				: [];
	}
}
