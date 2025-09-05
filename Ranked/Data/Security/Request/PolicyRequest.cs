namespace Ranked.Data.Security.Request
{
	using Interfaces;


	/// <inheritdoc/>
	public class PolicyRequest : IPolicyRequest
	{
		/// <inheritdoc/>
		public string Subject { get; }

		/// <inheritdoc/>
		public string Password { get; }


		/// <summary>
		/// Constructor for <see cref="PolicyRequest"/>
		/// </summary>
		/// <param name="subject">Role subject</param>
		/// <param name="password">Role password</param>
		public PolicyRequest(string subject, string password)
		{
			Subject = subject;
			Password = password;
		}
	}
}
