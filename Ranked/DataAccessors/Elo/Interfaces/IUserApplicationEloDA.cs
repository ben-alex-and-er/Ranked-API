using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.Elo.Interfaces
{
	using Data.Elo.DTOs;
	using Data.User.DTOs;


	/// <summary>
	/// Data accessor for the user_application_elo database table 
	/// </summary>
	public interface IUserApplicationEloDA : ICreate<UserApplicationEloDTO>, IRead<UserApplicationEloDTO>, IUpdate<UserApplicationDTO, uint>
	{
	}
}
