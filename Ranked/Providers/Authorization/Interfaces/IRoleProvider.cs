namespace Ranked.Providers.Authorization.Interfaces
{
	/// <summary>
	/// Provider for roles
	/// </summary>
	public interface IRoleProvider
	{
		/// <summary>
		/// Retrieves a dictionary of roles and associated hashedPasswords
		/// </summary>
		/// <returns>A dictionary of roles and associated hashedPasswords</returns>
		public Task<Dictionary<string, string>> GetRoles();
	}
}
