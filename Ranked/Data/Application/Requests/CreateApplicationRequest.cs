namespace Ranked.Data.Application.Requests
{
	using Interfaces;


	/// <inheritdoc/>
	public class CreateApplicationRequest : ICreateApplicationRequest
	{
		/// <inheritdoc/>
		public string Name { get; set; }

		/// <inheritdoc/>
		public Guid Guid { get; set; }
	}
}
