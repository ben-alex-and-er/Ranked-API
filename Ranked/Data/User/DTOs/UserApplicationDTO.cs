namespace Ranked.Data.User.DTOs
{
	using User.Interfaces;


	/// <summary>
	/// DTO containing a user and an application
	/// </summary>
	public class UserApplicationDTO : ICreateUserRequest
	{
		/// <summary>
		/// User Identifier
		/// </summary>
		public string User { get; set; }

		/// <summary>
		/// User's application
		/// </summary>
		public Guid Application { get; set; }
	}
}
