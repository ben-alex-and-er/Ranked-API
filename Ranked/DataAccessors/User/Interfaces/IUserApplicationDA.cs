using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.User.Interfaces
{
	using Data.User.DTOs;
	using Data.User.Interfaces;


	/// <summary>
	/// Data accessor for the user_application database table 
	/// </summary>
	public interface IUserApplicationDA : ICreate<ICreateUserRequest>, IRead<UserApplicationDTO>
	{
	}
}
