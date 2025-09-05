namespace Ranked.Data.Security.Interfaces
{
	/// <summary>
	/// Configuration Data for JWT Decriptor
	/// </summary>
	public interface IJWTDescriptor
	{
		/// <summary>
		/// The JWT Issuer
		/// </summary>
		public string Issuer { get; }

		/// <summary>
		/// The JWT Audience
		/// </summary>
		public string Audience { get; }

		/// <summary>
		/// The JWT Security Key
		/// </summary>
		public string SecurityKey { get; }
	}
}
