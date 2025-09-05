using System.Security.Claims;


namespace Ranked.Providers.Authorization.Claims
{
	using Policy;


	public static partial class Permissions
	{
		/// <summary>
		/// Application related permissions
		/// </summary>
		public static class Application
		{
			/// <summary>
			/// Application claim type
			/// </summary>
			public const string APPLICATION_CLAIM = nameof(Application);


			/// <summary>
			/// Application read claim
			/// </summary>
			public static readonly Claim read = new(APPLICATION_CLAIM, Policies.READ);

			/// <summary>
			/// Application write claim
			/// </summary>
			public static readonly Claim write = new(APPLICATION_CLAIM, Policies.WRITE);

			/// <summary>
			/// Application delete claim
			/// </summary>
			public static readonly Claim delete = new(APPLICATION_CLAIM, Policies.DELETE);
		}
	}
}
