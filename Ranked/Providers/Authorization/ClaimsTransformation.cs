using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace Ranked.Providers.Authorization
{
	using Interfaces;


	/// <inheritdoc/>
	public class ClaimsTransformation : IClaimsTransformation
	{
		private readonly IClaimsProvider claimsProvider;


		/// <summary>
		/// Constructor for <see cref="ClaimsTransformation"/>
		/// </summary>
		/// <param name="claimsProvider">Provider for claims</param>
		public ClaimsTransformation(IClaimsProvider claimsProvider)
		{
			this.claimsProvider = claimsProvider;
		}


		async Task<ClaimsPrincipal> IClaimsTransformation.TransformAsync(ClaimsPrincipal principal)
		{
			var role = principal.FindFirstValue(ClaimTypes.Role);

			if (role == null)
				return new ClaimsPrincipal();

			var claims = claimsProvider.GetRoleClaims(role);

			var identity = new ClaimsIdentity(principal.Identity, claims);

			return new ClaimsPrincipal(identity);
		}
	}
}
