using DataAccessors.Interfaces;


namespace Ranked.DataAccessors.Interfaces
{
	/// <summary>
	/// Data accessor for the user database table 
	/// </summary>
	public interface IUserDA : ICreate<string>, IRead<string>
	{

	}
}
