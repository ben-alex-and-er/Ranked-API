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
		public required string User { get; set; }

		/// <summary>
		/// User's application
		/// </summary>
		public required Guid Application { get; set; }


		public override bool Equals(object? obj)
		{
			if (obj is not UserApplicationDTO other)
				return false;

			return other.User == User && other.Application == Application;
		}

		public override int GetHashCode()
			=> HashCode.Combine(User, Application);
	}
}
