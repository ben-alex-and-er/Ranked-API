namespace Ranked.Providers.Authorization.Policy
{
	using Claims;
	using Data.Security;


	public static partial class Policies
	{
		/// <summary>
		/// User related Policies
		/// </summary>
		public static class User
		{
			/// <summary>
			/// Policy for read
			/// </summary>
			public const string READ_USER = $"{Permissions.User.USER_CLAIM}-{Policies.READ}";

			/// <summary>
			/// Policy for write
			/// </summary>
			public const string WRITE_USER = $"{Permissions.User.USER_CLAIM}-{Policies.WRITE}";

			/// <summary>
			/// Policy for delete
			/// </summary>
			public const string DELETE_USER = $"{Permissions.User.USER_CLAIM}-{Policies.DELETE}";


			/// <summary>
			/// PolicyClaim for User.Read permissions
			/// </summary>
			public static readonly PolicyClaim read = new(READ_USER, Permissions.User.read);

			/// <summary>
			/// PolicyClaim for User.Write permissions
			/// </summary>
			public static readonly PolicyClaim write = new(WRITE_USER, Permissions.User.write);

			/// <summary>
			/// PolicyClaim for User.Delete permissions
			/// </summary>
			public static readonly PolicyClaim delete = new(DELETE_USER, Permissions.User.delete);
		}
	}
}
