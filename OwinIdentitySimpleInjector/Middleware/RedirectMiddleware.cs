using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NLog;

namespace OwinIdentitySimpleInjector.Middleware
{
    public class RedirectMiddleware : OwinMiddleware
    {
        private OwinMiddleware _next;
        private ILogger _logger = LogManager.GetLogger("RedirectMiddleware");

        public RedirectMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            var url = context.Request.Uri;

            _logger.Info("Redirect demo, Begin Request");

            if (url.AbsoluteUri == "http://localhost:52995/test")
            {
                if (context.Request.User != null && context.Request.User.Identity.IsAuthenticated)
                {
                    //context.Response.StatusCode = 301;
                    //context.Response.Headers.Set("Location", "/home/authenticated");
                    await context.Response.WriteAsync("This feature is currently unavailable, even if the user is authenticated.");
                }
                else
                {
                    string urlToRedirect = "http://localhost:52995/Redirect.html";

                    // for example you can redirect the page response in the middleware, 301 is the status code of permanent redirect
                    context.Response.StatusCode = 301;
                    context.Response.Headers.Set("Location", urlToRedirect);
                }
            }
            else
            {
                await Next.Invoke(context);
            }
            _logger.Info("Redirect demo, End Request");
        }
    }
}