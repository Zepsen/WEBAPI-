using System;
using HashidsNet;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using WEB.Infrastructure.Hashers;

namespace WEB.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DecodeHashIdAttribute : ActionFilterAttribute
    {
        private readonly Hashids _hash = HasherHelper.GetInstance;
        private readonly string _routeKey;
        
        public DecodeHashIdAttribute(string key)
        {
            _routeKey = key;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = (filterContext.HttpContext.GetRouteValue(_routeKey) as string);
            filterContext.ActionArguments[_routeKey] = _hash.Decode(id).FirstOr(0);
        }


    }
}