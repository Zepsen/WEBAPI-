using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace WEB.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DecodeJsonAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _key;

        public DecodeJsonAttribute(string key = "json")
        {
            _key = key;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var data = await new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync();
            var json = JObject.Parse(data).ToObject<Dictionary<string, object>>();
            context.ActionArguments[_key] = json;
            await next();
        }
    }
}