namespace Ranked.Data.Authorization.DTOs
{
	using Security.Request.Interfaces;


	/// <summary>
	/// DTO containing a subject and a password
	/// </summary>
	public class SubjectPasswordDTO : IPolicyRequest
	{
		/// <summary>
		/// Subject
		/// </summary>
		public required string Subject { get; set; }

		/// <summary>
		/// Password
		/// </summary>
		public required string Password { get; set; }
	}
}
