using IOData.Output;


namespace Ranked.Services.Interfaces
{
	using Data.Elo.Interfaces;
	using Data.Elo.Responses;
	using Data.Elo.Status;


	/// <summary>
	/// Service responsible for elo business logic
	/// </summary>
	public interface IEloService
	{
		/// <summary>
		/// Performs an elo update for a 1v1 match between two players
		/// </summary>
		/// <param name="request">The request object containing match data</param>
		/// <returns>A <see cref="Task{TResult}"/> with a <see cref="Result{TError, TSuccess}"/> containing either a <see cref="_1v1Status"/> error or a <see cref="_1v1Response"/> result</returns>
		Task<Result<_1v1Status, _1v1Response>> _1v1(I1v1Request request);
	}
}
