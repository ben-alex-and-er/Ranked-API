using Ranked.Configuration.Database;
using Ranked.Configuration.Elo;
using Ranked.Configuration.Transaction;
using Ranked.Configuration.User;


internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);


		builder.Services.AddControllers();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();


		builder.Services
			.AddDatabaseContext()
			.AddEloServices()
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

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}