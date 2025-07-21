namespace Ranked.Providers.Authorization.Policy
{
	using Claims;
	using Data.Security;


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


			/// <summary>
			/// PolicyClaim for User.Read permissions
			/// </summary>
			public static readonly PolicyClaim read = new(READ, Permissions.User.read);

			/// <summary>
			/// PolicyClaim for User.Write permissions
			/// </summary>
			public static readonly PolicyClaim write = new(WRITE, Permissions.User.write);

			/// <summary>
			/// PolicyClaim for User.Delete permissions
			/// </summary>
			public static readonly PolicyClaim delete = new(DELETE, Permissions.User.delete);
		}
	}
}
