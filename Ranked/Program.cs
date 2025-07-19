using Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Ranked.Configuration.Elo;
using Ranked.Configuration.Transaction;
using Ranked.Configuration.User;
using Ranked.Models;


internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services
			.AddEloServices()
			.AddTransactionServices()
			.AddUserServices();

		builder.Services.AddSingleton<MySQLConnection>();

		builder.Services.AddDbContext<RankedContext>((serviceProvider, options) =>
		{
			var connectionString = serviceProvider.GetRequiredService<MySQLConnection>();

			options.UseMySql(connectionString.ToString(), ServerVersion.AutoDetect(connectionString.ToString()));
		});

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