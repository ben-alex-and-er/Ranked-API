namespace Ranked.Data.User.Status
{
	/// <summary>
	/// Status codes for performing a create user request
	/// </summary>
	public enum CreateUserStatus
	{
		/// <summary>
		/// Indicates the user was created successfully
		/// </summary>
		SUCCESS = 0,

		/// <summary>
		/// Indicates the new user failed to be created
		/// due to the user identifier already existing
		/// </summary>
		USER_ALREADY_EXISTS = 1,

		/// <summary>
		/// Indicates the new user failed to be created
		/// due to the user elo failing to be created
		/// </summary>
		FAILED_TO_CREATE_ELO = 2,
	}
}
