using Microsoft.Owin;
using Owin;
using NLog;
using OwinIdentitySimpleInjector.Middleware;

[assembly: OwinStartupAttribute(typeof(OwinIdentitySimpleInjector.Startup))]
namespace OwinIdentitySimpleInjector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = IdentityConfig.RegisterInjections(app);

            // OWIN logging addition
            //Microsoft.Owin.Logging.ILogger logger = app.CreateLogger<Startup>();
            //logger.WriteInformation("App is starting up");


            ConfigureAuth(app, container);

            Logger _logger;

            //// example with an inline function
            //app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            //{
            //    _logger.Info("Begin Request");
            //    await next.Invoke(env);
            //    _logger.Info("End Request");                
            //})));

            //// example with middleware type 
            //app.Use(typeof(OwinDemoMiddleware));

            //// example with middleware instance
            //var logginMiddleware = new LogginMiddleware();
            //app.Use(logginMiddleware);

            // example with redirect url
            app.Use(typeof(RedirectMiddleware));
        }
    }
}
