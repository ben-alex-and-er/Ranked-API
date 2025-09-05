using System.Security.Claims;


namespace Ranked.Providers.Authorization.Claims
{
	using Policy;


	public static partial class Permissions
	{
		/// <summary>
		/// User related permissions
		/// </summary>
		public static class User
		{
			/// <summary>
			/// User claim type
			/// </summary>
			public const string USER_CLAIM = nameof(User);


			/// <summary>
			/// User read claim
			/// </summary>
			public static readonly Claim read = new(USER_CLAIM, Policies.READ);

			/// <summary>
			/// User write claim
			/// </summary>
			public static readonly Claim write = new(USER_CLAIM, Policies.WRITE);

			/// <summary>
			/// User delete claim
			/// </summary>
			public static readonly Claim delete = new(USER_CLAIM, Policies.DELETE);
		}
	}
}
