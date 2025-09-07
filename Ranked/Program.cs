namespace Ranked
{
	using Configuration.Authentication;
	using Configuration.Authorization;
	using Configuration.Database;
	using Configuration.Elo;
	using Configuration.Security;
	using Configuration.Transaction;
	using Configuration.User;


	internal static class Program
	{
		private static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services
				.AddAuthorizationServices()
				.AddAuthenticationServices()
				.AddDatabaseContext()
				.AddEloServices()
				.AddSecurityServices()
				.AddTransactionServices()
				.AddUserServices();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}