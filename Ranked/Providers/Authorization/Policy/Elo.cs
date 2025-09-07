namespace Ranked.Providers.Authorization.Policy
{
	using Claims;
	using Data.Security;


	public static partial class Policies
	{
		/// <summary>
		/// Elo related Policies
		/// </summary>
		public static class Elo
		{
			/// <summary>
			/// Policy for read
			/// </summary>
			public const string READ_ELO = $"{Permissions.Elo.ELO_CLAIM}-{Policies.READ}";

			/// <summary>
			/// Policy for write
			/// </summary>
			public const string WRITE_ELO = $"{Permissions.Elo.ELO_CLAIM}-{Policies.WRITE}";


			/// <summary>
			/// PolicyClaim for Elo.Read permissions
			/// </summary>
			public static readonly PolicyClaim read = new(READ_ELO, Permissions.User.read);

			/// <summary>
			/// PolicyClaim for Elo.Write permissions
			/// </summary>
			public static readonly PolicyClaim write = new(WRITE_ELO, Permissions.User.write);
		}
	}
}
