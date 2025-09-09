using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.Authorization
{
	using Data.Authorization.DTOs;
	using Interfaces;
	using Providers.Authorization.Claims;


	public class RolePasswordDA : IRolePasswordDA
	{
		IQueryable<SubjectPasswordDTO> IRead<SubjectPasswordDTO>.Read()
			=> new List<SubjectPasswordDTO>()
			{
				new()
				{
					Subject = Permissions.Roles.READER,
					Password = "WjFWWmF6ZGFkV0l2VkU1Tk4wOUlLMkpQV2xaVGR6MDkuMTAwMDAwLlNIQTUxMi4zMi5lWFp0Tm1KMU5FZDBSa2RCTldOeWRtMW1ZbmN2TVhCa2NsbHFWMDFEZDNsT1FtZzVhVUZuUVZoU1RUMD0="
				},
				new()
				{
					Subject = Permissions.Roles.ADMIN,
					Password = "WjFWWmF6ZGFkV0l2VkU1Tk4wOUlLMkpQV2xaVGR6MDkuMTAwMDAwLlNIQTUxMi4zMi5lWFp0Tm1KMU5FZDBSa2RCTldOeWRtMW1ZbmN2TVhCa2NsbHFWMDFEZDNsT1FtZzVhVUZuUVZoU1RUMD0="
				},
			}.AsQueryable();
	}
}
