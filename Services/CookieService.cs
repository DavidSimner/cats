using System;
using System.Linq;
using Microsoft.AspNet.Http;

namespace cats.Services
{
    internal static class CookieService
    {
        private const string Key = "THE_SESSION_ID";
        
        internal static string GetOrCreateSession(HttpContext httpContext)
        {
            var cookie = httpContext.Request.Cookies[Key];
            if (!cookie.Any())
            {
                var value = Guid.NewGuid().ToString("N");
                httpContext.Response.Cookies.Append(Key, value);
                return value;
            }
            else
            {
                return cookie.Single();
            }
        }
    }
}
