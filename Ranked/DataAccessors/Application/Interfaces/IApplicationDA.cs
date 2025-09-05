using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.Application.Interfaces
{
	using Data.Common.DTOs;


	/// <summary>
	/// Data accessor for the application database table 
	/// </summary>
	public interface IApplicationDA : IRead<NameGuidDTO>
	{
	}
}
