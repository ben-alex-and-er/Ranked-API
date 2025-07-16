using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.Elo.Interfaces
{
	using Data.Elo.DTOs;


	/// <summary>
	/// Data accessor for the user_elo database table 
	/// </summary>
	public interface IUserEloDA : ICreate<UserEloDTO>, IRead<UserEloDTO>, IUpdate<string, uint>
	{
	}
}
