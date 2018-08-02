using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Infrastructure.Helpers
{
    public static class ReposHelper
    {
        public static Expression<Func<T, T>> UpdateSpecificFields<T>(Dictionary<string, object> dictionary)
        {
            var xParameter = Expression.Parameter(typeof(T));
            var xNew = Expression.New(typeof(T));

            var xBody = dictionary.Select(p =>
            {
                var left = typeof(T).GetProperty(p.Key);
                var right = Expression.Constant(dictionary[p.Key], typeof(T).GetProperty(p.Key).PropertyType);
                return Expression.Bind(left, right);
            });

            var xInit = Expression.MemberInit(xNew, xBody);
            return Expression.Lambda<Func<T, T>>(xInit, xParameter);
        }
    }
}