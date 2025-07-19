using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Linq.Expressions;


namespace Unit_Tests.TestHelpers
{
	internal class EFTestQueryable<T>(EnumerableQuery<T> enumerableQuery) : IOrderedQueryable<T>, IAsyncQueryProvider, IAsyncEnumerable<T>
	{
		Type IQueryable.ElementType => (enumerableQuery as IQueryable).ElementType;

		Expression IQueryable.Expression => (enumerableQuery as IQueryable).Expression;

		IQueryProvider IQueryable.Provider => this;


		IQueryable IQueryProvider.CreateQuery(Expression expression)
		{
			var elementType = expression.Type.GetGenericArguments().First();
			var t = typeof(EFTestQueryable<>).MakeGenericType(elementType);
			return Activator.CreateInstance(t, [enumerableQuery]) as IQueryable;
		}

		IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
			=> new EFTestQueryable<TElement>(new EnumerableQuery<TElement>(expression));

		object? IQueryProvider.Execute(Expression expression)
			=> (enumerableQuery as IQueryProvider).Execute(expression);

		TResult IQueryProvider.Execute<TResult>(Expression expression)
			=> (enumerableQuery as IQueryProvider).Execute<TResult>(expression);

		TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
		{
			var result = (this as IQueryProvider).Execute(expression);

			var taskResultType = typeof(TResult).GetGenericArguments()[0];
			var taskFromResultMethod = typeof(Task)
				.GetMethods()
				.First(m => m.Name == nameof(Task.FromResult) && m.IsGenericMethod)
				.MakeGenericMethod(taskResultType);

			return (TResult)taskFromResultMethod.Invoke(null, [result])!;
		}

		IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
			=> enumerableQuery.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
			=> (enumerableQuery as IEnumerable<T>).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> (enumerableQuery as IEnumerable<T>).GetEnumerator();
	}
}
