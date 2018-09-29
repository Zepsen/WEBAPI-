using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using WEB.Infrastructure.Hashers;

namespace WEB.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DecodeHashIdAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _routeKey;
        
        public DecodeHashIdAttribute(string key)
        {
            _routeKey = key;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (context.HttpContext.GetRouteValue(_routeKey) as string);
            context.ActionArguments[_routeKey] = HasherHelper.GetInstance.Decode(id).FirstOr(0);
            await next();
        }
    }
}