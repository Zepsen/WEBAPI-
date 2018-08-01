﻿using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Infrastructure.Filters;
using DAL.Models;

namespace BLL.Infrastructure.Extensions
{
    public static class FilteringExt
    {
        

        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> query, FilterBase filter)
        {
            if (filter.Skip.HasValue) query = query.Skip(filter.Skip.Value);
            if (filter.Take.HasValue) query = query.Take(filter.Take.Value);

            return query;
        }

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

        public static IQueryable<TModel> MapTo<T, TModel>(this IQueryable<T> query, string fields,
            IConfigurationProvider mapperConfigurationProvider)
        {
            return fields.IsNotNullOrEmpty() 
                ? query.Specific<T, TModel>(fields) 
                : query.ProjectTo<TModel>(mapperConfigurationProvider);
        }

    }
}