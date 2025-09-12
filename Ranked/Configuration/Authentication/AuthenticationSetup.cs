using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Ranked.Configuration.Authentication
{
	using Data.Security;
	using Data.Security.Interfaces;


	public static class AuthenticationSetup
	{
		/// <summary>
		/// Adds authentication related services for injection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
		{
			services.AddSingleton<IJwtDescriptor, JwtDescriptor>();

			var provider = services.BuildServiceProvider();
			var jwtDescriptor = provider.GetRequiredService<IJwtDescriptor>();

			services.AddAuthentication("Bearer")
				.AddJwtBearer("Bearer", options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,

						ValidIssuer = jwtDescriptor.Issuer,
						ValidAudience = jwtDescriptor.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtDescriptor.SecurityKey))
					};
				});

			return services;
		}
	}
}
