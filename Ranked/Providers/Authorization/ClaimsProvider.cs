using System.Security.Claims;


namespace Ranked.Providers.Authorization
{
	using Claims;
	using Interfaces;


	/// <inheritdoc/>
	[Obsolete("This should be using the Database")]
	public class ClaimsProvider : IClaimsProvider
	{
		private static readonly Dictionary<string, List<Claim>> roles = new()
		{
			{ Permissions.Roles.READER, new List<Claim>(){ new(ClaimTypes.Role, Permissions.Roles.READER) } },
			{ Permissions.Roles.ADMIN, new List<Claim>(){ new(ClaimTypes.Role, Permissions.Roles.ADMIN) } }
		};


		IEnumerable<Claim> IClaimsProvider.GetClaims(string role)
			=> roles.TryGetValue(role, out var claims)
				? claims
				: [];
	}
}
