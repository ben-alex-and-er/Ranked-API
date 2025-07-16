namespace Ranked.Services.User
{
	using Data.Elo.DTOs;
	using Data.User.Interfaces;
	using Data.User.Responses;
	using Data.User.Status;
	using DataAccessors.Elo.Interfaces;
	using DataAccessors.User.Interfaces;
	using Interfaces;
	using Models;


	/// <inheritdoc/>
	public class UserService : IUserService
	{
		private const uint INITIAL_ELO = 1500;


		private readonly RankedContext context;

		private readonly IUserDA userDA;
		private readonly IUserEloDA userEloDA;


		/// <summary>
		/// Constructor for <see cref="UserService"/>
		/// </summary>
		/// <param name="context">Database Context</param>
		/// <param name="userDA">Data accessor for the user database table</param>
		/// <param name="userEloDA">Data accessor for the user_elo database table</param>
		public UserService(RankedContext context, IUserDA userDA, IUserEloDA userEloDA)
		{
			this.context = context;
			this.userDA = userDA;
			this.userEloDA = userEloDA;
		}


		async Task<CreateUserResponse> IUserService.Create(ICreateUserRequest request)
		{
			using var transaction = context.Database.BeginTransaction();

			var create = await userDA.Create(request.User);

			if (!create)
				return new CreateUserResponse(CreateUserStatus.USER_ALREADY_EXISTS);

			var createElo = await userEloDA.Create(new UserEloDTO
			{
				User = request.User,
				Elo = INITIAL_ELO
			});

			if (!createElo)
				return new CreateUserResponse(CreateUserStatus.FAILED_TO_CREATE_ELO);

			transaction.Commit();

			return new CreateUserResponse(CreateUserStatus.SUCCESS);
		}
	}
}
