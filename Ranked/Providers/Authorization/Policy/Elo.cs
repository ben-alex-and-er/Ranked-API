namespace Ranked.Providers.Authorization.Policy
{
	using Claims;
	using Data.Security;


	public static partial class Policies
	{
		/// <summary>
		/// Elo related Policies
		/// </summary>
		public class Elo
		{
			/// <summary>
			/// Policy for read
			/// </summary>
			public const string READ = $"{Permissions.Elo.ELO_CLAIM}-{Policies.READ}";

			/// <summary>
			/// Policy for write
			/// </summary>
			public const string WRITE = $"{Permissions.Elo.ELO_CLAIM}-{Policies.WRITE}";


			/// <summary>
			/// PolicyClaim for Elo.Read permissions
			/// </summary>
			public static readonly PolicyClaim read = new(READ, Permissions.Elo.read);

			/// <summary>
			/// PolicyClaim for Elo.Write permissions
			/// </summary>
			public static readonly PolicyClaim write = new(WRITE, Permissions.Elo.write);
		}
	}
}
