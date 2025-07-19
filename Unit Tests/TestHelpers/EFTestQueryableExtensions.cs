namespace Unit_Tests.TestHelpers
{
	internal static class EFTestQueryableExtensions
	{
		public static IQueryable<T> AsEFTestQueryable<T>(this IEnumerable<T> enumerable)
			=> new EFTestQueryable<T>(new EnumerableQuery<T>(enumerable));
	}
}
