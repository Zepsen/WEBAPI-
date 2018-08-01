﻿using System.Linq;
using DAL.Models;

namespace BLL.Infrastructure.Extensions.EntitiesExts
{
    public static class CompaniesExt
    {
        public static IQueryable<Companies> Searching(this IQueryable<Companies> query, string search)
        {
            return search.IsNullOrEmpty() ? query : query.Where(i => i.Name.Contains(search));
        }

        
    }
}