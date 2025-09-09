using GateKeeper.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Ranked.Services.Security
{
	using Data.Security.Interfaces;
	using Data.Security.Request.Interfaces;
	using Interfaces;
	using Providers.Authorization.Interfaces;


	/// <inheritdoc/>
	public class SecurityService : ISecurityService
	{
		private readonly IJwtDescriptor jwtDescriptor;

		private readonly IClaimsProvider claimsProvider;

		private readonly IRoleProvider roleProvider;


		/// <summary>
		/// Constructor for <see cref="SecurityService"/>
		/// </summary>
		/// <param name="jwtDescriptor">JWT Descriptor</param>
		/// <param name="claimsProvider">Claims Provider</param>
		/// <param name="roleProvider">Role Provider</param>
		public SecurityService(IJwtDescriptor jwtDescriptor, IClaimsProvider claimsProvider, IRoleProvider roleProvider)
		{
			this.jwtDescriptor = jwtDescriptor;
			this.claimsProvider = claimsProvider;
			this.roleProvider = roleProvider;
		}


		async Task<IActionResult> ISecurityService.GetPolicyToken(IPolicyRequest request)
		{
			var validity = await Validate(request);

			if (!validity)
				return new UnauthorizedObjectResult(validity.ToString());

			var token = CreateToken(request.Subject, DateTime.UtcNow.AddHours(1));

			return new OkObjectResult(token);
		}


		private async Task<bool> Validate(IPolicyRequest request)
		{
			var hashPassword = await roleProvider.GetHashedPassword(request.Subject);

			if (string.IsNullOrEmpty(hashPassword))
				return false;

			if (!PasswordHasher.VerifyPassword(request.Password, new HashedPassword(hashPassword)))
				return false;

			return true;
		}

		private string CreateToken(string subject, DateTime expiry)
		{
			var claims = claimsProvider.GetSubjectClaims(subject);

			var now = DateTime.UtcNow;

			var tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				IssuedAt = now,
				NotBefore = now,
				Expires = expiry,
				Issuer = jwtDescriptor.Issuer,
				Audience = jwtDescriptor.Audience,
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtDescriptor.SecurityKey)),
					SecurityAlgorithms.HmacSha256)
			};

			var hander = new JwtSecurityTokenHandler();

			var token = hander.CreateEncodedJwt(tokenDescription);

			return token;
		}
	}
}
