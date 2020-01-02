using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProxyApi.Filters
{
    public class VerifyAccessFilter : IActionFilter
    {
        public string _headerName;
        public string _apiKey;

        public VerifyAccessFilter(string headerName, string apiKey)
        {
            _headerName = headerName;
            _apiKey = apiKey;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var containsHeader = context.HttpContext.Request.Headers.ContainsKey(_headerName);

            if (!containsHeader)
            {

                context.HttpContext.Response.StatusCode = 401;
                context.Result = new ContentResult();
            }

            var clientApiKey = context.HttpContext.Request.Headers[_headerName];

            if (clientApiKey != _apiKey)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new ContentResult();
            }

        }
    }
}