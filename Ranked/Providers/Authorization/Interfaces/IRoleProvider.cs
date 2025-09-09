namespace Ranked.Providers.Authorization.Interfaces
{
	/// <summary>
	/// Provider for roles
	/// </summary>
	public interface IRoleProvider
	{
		/// <summary>
		/// Retrieves a hashed password for the provided role
		/// </summary>
		/// <param name="role">Role to find hashed password for</param>
		/// <returns>The hashed password for the provided role of roles</returns>
		public Task<string?> GetHashedPassword(string role);
	}
}
