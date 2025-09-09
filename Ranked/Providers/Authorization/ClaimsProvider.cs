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


		IEnumerable<Claim> IClaimsProvider.GetSubjectClaims(string role)
			=> roles.TryGetValue(role, out var claims)
				? claims
				: [];

		IEnumerable<Claim> IClaimsProvider.GetRoleClaims(string role) => role switch
		{
			Permissions.Roles.READER => readerClaims,
			Permissions.Roles.ADMIN => adminClaims,
			_ => []
		};
	}
}
