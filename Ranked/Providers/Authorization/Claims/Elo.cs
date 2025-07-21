using System.Security.Claims;


namespace Ranked.Providers.Authorization.Claims
{
	using Policy;


	public static partial class Permissions
	{
		/// <summary>
		/// Elo related permissions
		/// </summary>
		public static class Elo
		{
			/// <summary>
			/// Elo claim type
			/// </summary>
			public const string ELO_CLAIM = nameof(Elo);


			/// <summary>
			/// Elo read claim
			/// </summary>
			public static readonly Claim read = new(ELO_CLAIM, Policies.READ);

			/// <summary>
			/// Elo write claim
			/// </summary>
			public static readonly Claim write = new(ELO_CLAIM, Policies.WRITE);

			/// <summary>
			/// Elo delete claim
			/// </summary>
			public static readonly Claim delete = new(ELO_CLAIM, Policies.DELETE);
		}
	}
}
