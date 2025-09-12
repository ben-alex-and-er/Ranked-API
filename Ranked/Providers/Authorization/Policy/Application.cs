namespace Ranked.Providers.Authorization.Policy
{
	using Claims;
	using Data.Security;


	public static partial class Policies
	{
		/// <summary>
		/// Application related Policies
		/// </summary>
		public static class Application
		{
			/// <summary>
			/// Policy for read
			/// </summary>
			public const string READ_APPLICATION = $"{Permissions.Application.APPLICATION_CLAIM}-{Policies.READ}";

			/// <summary>
			/// Policy for write
			/// </summary>
			public const string WRITE_APPLICATION = $"{Permissions.Application.APPLICATION_CLAIM}-{Policies.WRITE}";


			/// <summary>
			/// PolicyClaim for Application.Read permissions
			/// </summary>
			public static readonly PolicyClaim read = new(READ_APPLICATION, Permissions.Application.read);

			/// <summary>
			/// PolicyClaim for Application.Write permissions
			/// </summary>
			public static readonly PolicyClaim write = new(WRITE_APPLICATION, Permissions.Application.write);
		}
	}
}
