using Microsoft.EntityFrameworkCore;


namespace Ranked.Providers.Authorization
{
	using DataAccessors.Authorization.Interfaces;
	using Interfaces;


	/// <inheritdoc/>
	public class RoleProvider : IRoleProvider
	{
		private readonly IRolePasswordDA rolePasswordDA;


		/// <summary>
		/// Constructor for <see cref="IRolePasswordDA"/>
		/// </summary>
		/// <param name="rolePasswordDA"></param>
		public RoleProvider(IRolePasswordDA rolePasswordDA)
		{
			this.rolePasswordDA = rolePasswordDA;
		}


		async Task<string?> IRoleProvider.GetHashedPassword(string role)
		{
			var rolePassword = await rolePasswordDA.Read()
				.FirstOrDefaultAsync(rolePassword => rolePassword.Subject == role);

			return rolePassword?.Password;
		}
	}
}
