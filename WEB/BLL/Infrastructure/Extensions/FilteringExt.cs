using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BLL.Infrastructure.Filters;
using Z.EntityFramework.Plus;
using System.Linq.Dynamic.Core;

namespace BLL.Infrastructure.Extensions
{
    /// <summary>
    /// Extensions for filtering get query
    /// </summary>
    public static class FilteringExt
    {
        
        /// <summary>
        /// Skip and take logic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> query, FilterBase filter)
        {
            if (filter.Skip.HasValue) query = query.Skip(filter.Skip.Value);
            if (filter.Take.HasValue) query = query.Take(filter.Take.Value);

            return query;
        }

        /// <summary>
        /// Create default Result for getter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<Result<T>> ToResultAsync<T>(this IQueryable<T> query, FilterBase filter)
        {
            return new Result<T>
            {
                Total = (filter.Skip.HasValue || filter.Take.HasValue) ? query.DeferredCount().FutureValue() : -1,
                Pagination = filter.Skip.HasValue || filter.Take.HasValue,
                Data = await query.Future().ToListAsync()
            };
        }

        /// <summary>
        /// Specify concrete fields from db, using DTOmodel as a retrieve model
        /// !!!Can be problem if dto fields different than entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        [Obsolete("use Linq.Dynamic")]
        public static IQueryable<TModel> Specific<T, TModel>(this IQueryable<T> query, string fields)
        {
            var xParameter = Expression.Parameter(typeof(T), "o");
            var xNew = Expression.New(typeof(TModel));

            var bindings = fields.Split(',')
                .Select(o => o.Trim())
                .Select(paramName =>
                    {
                        var xOriginal = Expression.Property(xParameter, typeof(T).GetProperty(paramName));
                        return Expression.Bind(typeof(TModel).GetProperty(paramName), xOriginal);
                    }
                );
            var xInit = Expression.MemberInit(xNew, bindings);

            var lambda = Expression.Lambda<Func<T, TModel>>(xInit, xParameter);

            return query.Select(lambda);
        }
        
        /// <summary>
        /// Specify concrete fields from db, using EntityModel as a retrieve model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        [Obsolete("use Linq.Dynamic")]
        public static IQueryable<T> OnlySpecific<T>(this IQueryable<T> query, string fields)
        {
            if (fields.IsNullOrEmpty()) return query;

            var xParameter = Expression.Parameter(typeof(T), "o");
            var xNew = Expression.New(typeof(T));

            var bindings = fields.Split(',')
                .Select(o => o.Trim())
                .Select(paramName =>
                    {
                        var xOriginal = Expression.Property(xParameter, typeof(T).GetProperty(paramName));
                        return Expression.Bind(typeof(T).GetProperty(paramName), xOriginal);
                    }
                );

            var xInit = Expression.MemberInit(xNew, bindings);
            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            return query.Select(lambda);
        }

        /// <summary>
        /// OrderBy wrapper for Linq.Dynamic.Core;
        /// Ordering if existing 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static IQueryable<T> MaybeOrderBy<T>(this IQueryable<T> query, string orderby)
        {
            return orderby.IsNullOrEmpty() ? query : query.OrderBy(orderby);
        }

        /// <summary>
        /// Select wrapper for Linq.Dynamic.Core;
        /// Selecting specific fields, if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static IQueryable MaybeSelect<T>(this IQueryable<T> query, string select)
        {
            return select.IsNullOrEmpty() ? query : query.Select(select);
        }

        /// <summary>
        /// Select wrapper for Linq.Dynamic.Core;
        /// Filterind data, if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IQueryable<T> MaybeWhere<T>(this IQueryable<T> query, string where)
        {
            return where.IsNullOrEmpty() ? query : query.Where(where);
        }

    }
}