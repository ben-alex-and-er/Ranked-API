namespace Ranked.Data.Application.Requests
{
	using Interfaces;


	/// <inheritdoc/>
	public class CreateApplicationRequest : ICreateApplicationRequest
	{
		/// <inheritdoc/>
		public string Name { get; }

		/// <inheritdoc/>
		public Guid Guid { get; }


		/// <summary>
		/// Constructor for <see cref="CreateApplicationRequest"/>
		/// </summary>
		/// <param name="name">New application name</param>
		/// <param name="guid">New application guid</param>
		public CreateApplicationRequest(string name, Guid guid)
		{
			Name = name;
			Guid = guid;
		}
	}
}
