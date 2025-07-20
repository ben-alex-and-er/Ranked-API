namespace Ranked.Providers.Authorization.Policy
{
	using Claims;


	public static partial class Policies
	{
		/// <summary>
		/// User related Policies
		/// </summary>
		public class User
		{
			/// <summary>
			/// Policy for read
			/// </summary>
			public const string READ = $"{Permissions.User.USER_CLAIM}-{Policies.READ}";

			/// <summary>
			/// Policy for write
			/// </summary>
			public const string WRITE = $"{Permissions.User.USER_CLAIM}-{Policies.WRITE}";

			/// <summary>
			/// Policy for delete
			/// </summary>
			public const string DELETE = $"{Permissions.User.USER_CLAIM}-{Policies.DELETE}";
		}
	}
}
