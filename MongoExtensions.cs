using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepository
{
    public static class MongoExtensions
    {
        public static IQueryable<TResult> Select<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, TResult>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Select(mongoQueryable, filter);
            }

            return Queryable.Select(queryable, filter);
        }

        public static IQueryable<TResult> SelectMany<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, IEnumerable<TResult>>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.SelectMany(mongoQueryable, filter);
            }

            return Queryable.SelectMany(queryable, filter);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Where(mongoQueryable, filter);
            }

            return Queryable.Where(queryable, filter);
        }

        public static IQueryable<T> Distinct<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Distinct(mongoQueryable);
            }

            return Queryable.Distinct(queryable);
        }

        public static IQueryable<T> OrderBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.OrderBy(mongoQueryable, filter);
            }

            return Queryable.OrderBy(queryable, filter);
        }

        public static IOrderedQueryable<T> OrderByDescending<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.OrderByDescending(mongoQueryable, filter);
            }

            return Queryable.OrderByDescending(queryable, filter);
        }

        public static IQueryable<T> ThenBy<T, TKey>(this IOrderedQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IOrderedMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.ThenBy(mongoQueryable, filter);
            }

            return Queryable.ThenBy(queryable, filter);
        }

        public static IQueryable<T> ThenByDescending<T, TKey>(this IOrderedQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IOrderedMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.ThenByDescending(mongoQueryable, filter);
            }

            return Queryable.ThenByDescending(queryable, filter);
        }

        public static IQueryable<TResult> OfType<TResult>(this IQueryable queryable)
        {
            if (queryable is IMongoQueryable mongoQueryable)
            {
                return MongoQueryable.OfType<TResult>(mongoQueryable);
            }

            return Queryable.OfType<TResult>(queryable);
        }

        public static IQueryable<IGrouping<TKey, T>> GroupBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.GroupBy(mongoQueryable, filter);
            }

            return Queryable.GroupBy(queryable, filter);
        }

        public static IQueryable<T> Skip<T>(this IQueryable<T> queryable, int count)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Skip(mongoQueryable, count);
            }

            return Queryable.Skip(queryable, count);
        }

        public static IQueryable<T> Take<T>(this IQueryable<T> queryable, int count)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Take(mongoQueryable, count);
            }

            return Queryable.Take(queryable, count);
        }

        public static ValueTask<bool> AnyAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<bool>(MongoQueryable.AnyAsync(mongoQueryable, filter));
            }

            return new ValueTask<bool>(Queryable.Any(queryable, filter));
        }

        public static ValueTask<TResult> MinAsync<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, TResult>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<TResult>(MongoQueryable.MinAsync(mongoQueryable, filter));
            }

            return new ValueTask<TResult>(Queryable.Min(queryable, filter));
        }

        public static ValueTask<TResult> MaxAsync<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, TResult>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<TResult>(MongoQueryable.MaxAsync(mongoQueryable, filter));
            }

            return new ValueTask<TResult>(Queryable.Max(queryable, filter));
        }

        public static ValueTask<T> FirstAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.FirstAsync(mongoQueryable));
            }

            return new ValueTask<T>(Queryable.First(queryable));
        }

        public static ValueTask<T> FirstAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.FirstAsync(mongoQueryable, filter));
            }

            return new ValueTask<T>(Queryable.First(queryable, filter));
        }

        public static ValueTask<T> FirstOrDefaultAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.FirstOrDefaultAsync(mongoQueryable));
            }

            return new ValueTask<T>(Queryable.FirstOrDefault(queryable));
        }

        public static ValueTask<T> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.FirstOrDefaultAsync(mongoQueryable, filter));
            }

            return new ValueTask<T>(Queryable.FirstOrDefault(queryable, filter));
        }

        public static ValueTask<T> SingleAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.SingleAsync(mongoQueryable));
            }

            return new ValueTask<T>(Queryable.Single(queryable));
        }

        public static ValueTask<T> SingleAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.SingleAsync(mongoQueryable, filter));
            }

            return new ValueTask<T>(Queryable.Single(queryable, filter));
        }

        public static ValueTask<T> SingleOrDefaultAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.SingleOrDefaultAsync(mongoQueryable));
            }

            return new ValueTask<T>(Queryable.SingleOrDefault(queryable));
        }

        public static ValueTask<T> SingleOrDefaultAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<T>(MongoQueryable.SingleOrDefaultAsync(mongoQueryable, filter));
            }

            return new ValueTask<T>(Queryable.SingleOrDefault(queryable, filter));
        }

        public static ValueTask<int> CountAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<int>(MongoQueryable.CountAsync(mongoQueryable));
            }

            return new ValueTask<int>(Queryable.Count(queryable));
        }

        public static ValueTask<int> CountAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return new ValueTask<int>(MongoQueryable.CountAsync(mongoQueryable, filter));
            }

            return new ValueTask<int>(Queryable.Count(queryable, filter));
        }

        public static ValueTask<List<T>> ToListAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IAsyncCursorSource<T> cursorSource)
            {
                return new ValueTask<List<T>>(cursorSource.ToListAsync());
            }

            return new ValueTask<List<T>>(queryable.ToList());
        }
    }
}
