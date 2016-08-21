using NSubstitute;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;

namespace OwinIdentitySimpleInjector.Tests
{
    public class HttpContextTest
    {
        protected static HttpRequestBase HttpRequestBase;
        protected static HttpResponseBase HttpResponseBase;
        protected static HttpSessionStateBase HttpSessionStateBase;
        protected static HttpServerUtilityBase HttpServerUtilityBase;

        public static HttpContextBase GetMockedHttpContext(IPrincipal userContext = null)
        {
            var context = Substitute.For<HttpContextBase>();
            HttpRequestBase = Substitute.For<HttpRequestBase>();
            HttpResponseBase = Substitute.For<HttpResponseBase>();
            HttpSessionStateBase = Substitute.For<HttpSessionStateBase>();
            HttpServerUtilityBase = Substitute.For<HttpServerUtilityBase>();
            HttpCachePolicy = Substitute.For<HttpCachePolicyBase>();

            context.Request.Returns(HttpRequestBase);
            context.Response.Returns(HttpResponseBase);
            context.Session.Returns(HttpSessionStateBase);
            context.Server.Returns(HttpServerUtilityBase);
            context.User = userContext;

            HttpResponseBase.Cache.Returns(HttpCachePolicy);

            Dictionary<string, object> owinEnvironment = new Dictionary<string, object>()
            {
                {"owin.RequestBody", null},
                {"server.User", userContext}
            };
            Dictionary<object, object> itemDictionary = new Dictionary<object, object>();
            itemDictionary.Add("owin.Environment", owinEnvironment);

            context.Items.Returns(itemDictionary);

            return context;
        }

        protected static HttpCachePolicyBase HttpCachePolicy;
    }
}
