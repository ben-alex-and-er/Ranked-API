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
		/// due to the application not existing
		/// could not be found
		/// </summary>
		APPLICATION_NOT_FOUND = 1,

		/// <summary>
		/// Indicates the new user failed to be created
		/// due to the user application combination already existing
		/// </summary>
		USER_APPLICATION_ALREADY_EXISTS = 2,

		/// <summary>
		/// Indicates the new user failed to be created
		/// due to the user application elo failing to be created
		/// </summary>
		FAILED_TO_CREATE_ELO = 3,

		/// <summary>
		/// Indicates the new user failed to be created
		/// due to an unknown reason
		/// </summary>
		UNEXPECTED_ERROR = 4,
	}
}
