namespace Ranked.Data.Elo.Requests
{
	using Interfaces;
	using User.DTOs;


	/// <inheritdoc/>
	public class _1v1Request : I1v1Request
	{
		/// <inheritdoc/>
		public UserApplicationDTO Winner { get; }

		/// <inheritdoc/>
		public UserApplicationDTO Loser { get; }


		/// <summary>
		/// Constructor for <see cref="_1v1Request"/>
		/// </summary>
		/// <param name="winner">The user application of the winner</param>
		/// <param name="loser">The user application of the loser</param>
		public _1v1Request(UserApplicationDTO winner, UserApplicationDTO loser)
		{
			Winner = winner;
			Loser = loser;
		}
	}
}
