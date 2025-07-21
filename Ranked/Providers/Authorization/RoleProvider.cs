namespace Ranked.Providers.Authorization
{
	using Claims;
	using Interfaces;


	/// <inheritdoc/>
	[Obsolete("This should be using the Database")]
	public class RoleProvider : IRoleProvider
	{
		private static readonly Dictionary<string, string> subjectMap = new()
		{
			{ Permissions.Roles.READER, "WjFWWmF6ZGFkV0l2VkU1Tk4wOUlLMkpQV2xaVGR6MDkuMTAwMDAwLlNIQTUxMi4zMi5lWFp0Tm1KMU5FZDBSa2RCTldOeWRtMW1ZbmN2TVhCa2NsbHFWMDFEZDNsT1FtZzVhVUZuUVZoU1RUMD0=" },
			{ Permissions.Roles.ADMIN, "WjFWWmF6ZGFkV0l2VkU1Tk4wOUlLMkpQV2xaVGR6MDkuMTAwMDAwLlNIQTUxMi4zMi5lWFp0Tm1KMU5FZDBSa2RCTldOeWRtMW1ZbmN2TVhCa2NsbHFWMDFEZDNsT1FtZzVhVUZuUVZoU1RUMD0=" }
		};


		Task<Dictionary<string, string>> IRoleProvider.GetRoles()
			=> Task.FromResult(subjectMap);
	}
}
