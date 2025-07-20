namespace Ranked.Data.Security
{
	using Interfaces;


	/// <inheritdoc/>
	public class JWTDescriptor : IJWTDescriptor
	{
		private const string KEY = "JWTDescriptor";


		/// <inheritdoc/>
		public string Issuer { get; set; }

		/// <inheritdoc/>
		public string Audience { get; set; }

		/// <inheritdoc/>
		public string SecurityKey { get; set; }


		/// <summary>
		/// Constructor for <see cref="JWTDescriptor"/>
		/// </summary>
		/// <param name="configuration"></param>
		public JWTDescriptor(IConfiguration configuration)
		{
			configuration.Bind(KEY, this);
		}
	}
}
