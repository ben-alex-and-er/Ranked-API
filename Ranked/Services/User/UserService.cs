using Microsoft.EntityFrameworkCore;
using TransactionToolkit.Interfaces;


namespace Ranked.Services.User
{
	using Data.User.Interfaces;
	using Data.User.Responses;
	using Data.User.Status;
	using DataAccessors.Application.Interfaces;
	using DataAccessors.Elo.Extensions;
	using DataAccessors.Elo.Interfaces;
	using DataAccessors.User.Interfaces;
	using Interfaces;


	/// <inheritdoc/>
	public class UserService : IUserService
	{
		private readonly ITransactionCreator transactionCreator;

		private readonly IApplicationDA applicationDA;
		private readonly IUserDA userDA;
		private readonly IUserApplicationDA userApplicationDA;
		private readonly IUserApplicationEloDA userApplicationEloDA;


		/// <summary>
		/// Constructor for <see cref="UserService"/>
		/// </summary>
		/// <param name="transactionCreator">Transaction creator</param>
		/// <param name="applicationDA">Data accessor for the application database table</param>
		/// <param name="userDA">Data accessor for the user database table</param>
		/// <param name="userApplicationDA">Data accessor for the user_application database table</param>
		/// <param name="userApplicationEloDA">Data accessor for the user_application_elo database table</param>
		public UserService(
			ITransactionCreator transactionCreator,
			IApplicationDA applicationDA,
			IUserDA userDA,
			IUserApplicationDA userApplicationDA,
			IUserApplicationEloDA userApplicationEloDA)
		{
			this.transactionCreator = transactionCreator;
			this.applicationDA = applicationDA;
			this.userDA = userDA;
			this.userApplicationDA = userApplicationDA;
			this.userApplicationEloDA = userApplicationEloDA;
		}


		async Task<CreateUserResponse> IUserService.Create(ICreateUserRequest request)
		{
			var applicationExists = await applicationDA.Read()
				.AnyAsync(app => app.Guid == request.Application);

			if (!applicationExists)
				return new CreateUserResponse(CreateUserStatus.APPLICATION_NOT_FOUND);


			using var transaction = await transactionCreator.CreateTransactionAsync();


			var userExists = await userDA.Read()
				.AnyAsync(user => user == request.User);

			if (!userExists)
			{
				var createUser = await userDA.Create(request.User);

				if (!createUser)
					throw new InvalidOperationException("Failed to create user. This should not happen since user does not exist.");
			}


			var createUserApplication = await userApplicationDA.Create(request);

			if (!createUserApplication)
				return new CreateUserResponse(CreateUserStatus.USER_APPLICATION_ALREADY_EXISTS);


			var createElo = await userApplicationEloDA.Create(request);

			if (!createElo)
				return new CreateUserResponse(CreateUserStatus.FAILED_TO_CREATE_ELO);


			transaction.Commit();

			return new CreateUserResponse(CreateUserStatus.SUCCESS);
		}
	}
}
