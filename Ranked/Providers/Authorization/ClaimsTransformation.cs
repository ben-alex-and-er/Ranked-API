using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace Ranked.Providers.Authorization
{
	using Claims;


	/// <inheritdoc/>
	[Obsolete("This should be using the Database")]
	public class ClaimsTransformation : IClaimsTransformation
	{
		private readonly List<Claim> readerClaims =
		[
			Permissions.User.read,
			Permissions.Elo.read
		];

		private readonly List<Claim> adminClaims =
		[
			Permissions.User.read,
			Permissions.User.write,
			Permissions.User.delete,

			Permissions.Elo.read,
			Permissions.Elo.write,
			Permissions.Elo.delete
		];


		async Task<ClaimsPrincipal> IClaimsTransformation.TransformAsync(ClaimsPrincipal principal)
		{
			var role = principal.FindFirstValue(ClaimTypes.Role);

			if (role == null)
				return new ClaimsPrincipal();

			var claims = GetRoleClaims(role);

			var identity = new ClaimsIdentity(principal.Identity, claims);

			return new ClaimsPrincipal(identity);
		}


		private List<Claim> GetRoleClaims(string role) => role switch
		{
			Permissions.Roles.READER => readerClaims,
			Permissions.Roles.ADMIN => adminClaims,
			_ => []
		};
	}
}
