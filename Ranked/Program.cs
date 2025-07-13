using Microsoft.EntityFrameworkCore;
using Ranked.Configuration;
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

		builder.Services.AddUserServices();

		var connectionString = "server=localhost;port=1205;user=root;password=ranked;database=ranked;";

		builder.Services.AddDbContext<RankedContext>(options =>
			options.UseMySql(connectionString,
				ServerVersion.AutoDetect(connectionString)));

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