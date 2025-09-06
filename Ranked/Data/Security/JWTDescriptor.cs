namespace Ranked.Data.Security
{
	using Interfaces;


	/// <inheritdoc/>
	public class JwtDescriptor : IJwtDescriptor
	{
		private const string KEY = "JWTDescriptor";


		/// <inheritdoc/>
		public string Issuer { get; set; }

		/// <inheritdoc/>
		public string Audience { get; set; }

		/// <inheritdoc/>
		public string SecurityKey { get; set; }


		/// <summary>
		/// Constructor for <see cref="JwtDescriptor"/>
		/// </summary>
		/// <param name="configuration"></param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		public JwtDescriptor(IConfiguration configuration)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		{
			configuration.Bind(KEY, this);
		}
	}
}
