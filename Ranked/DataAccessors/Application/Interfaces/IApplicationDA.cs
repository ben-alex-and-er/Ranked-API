using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.Application.Interfaces
{
	using Data.Application.Requests.Interfaces;
	using Data.Common.DTOs;


	/// <summary>
	/// Data accessor for the application database table 
	/// </summary>
	public interface IApplicationDA : ICreate<ICreateApplicationRequest>, IRead<NameGuidDTO>
	{
	}
}
