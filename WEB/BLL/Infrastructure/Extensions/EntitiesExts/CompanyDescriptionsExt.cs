using System.Linq;
using DAL.Models;

namespace BLL.Infrastructure.Extensions.EntitiesExts
{
    public static class CompanyDescriptionsExt
    {
        public static IQueryable<CompanyDescriptions> Searching(this IQueryable<CompanyDescriptions> query, string search)
        {
            return search.IsNullOrEmpty() ? query : query.Where(i => i.Description.Contains(search));
        }

        
    }
}