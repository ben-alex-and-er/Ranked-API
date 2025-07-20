using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Unit_Tests.TestHelpers
{
	internal class MockDbContextFactory<T> : IDbContextFactory<T> where T : DbContext
	{
		private readonly string name;


		public MockDbContextFactory(string? name = null)
		{
			this.name = name ?? Guid.NewGuid().ToString();
		}


		public T CreateDbContext()
		{
			var services = new ServiceCollection();
			services.AddEntityFrameworkInMemoryDatabase();

			// Fresh service provider is needed to not use MySQL from RankedContext
			var serviceProvider = services.BuildServiceProvider();

			var options = new DbContextOptionsBuilder<T>()
				.UseInMemoryDatabase(name)
				.UseInternalServiceProvider(serviceProvider)
				.Options;

			return (T)Activator.CreateInstance(typeof(T), options)!;
		}
	}
}
