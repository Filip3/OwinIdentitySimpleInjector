using System.Collections.Generic;
using System.Threading.Tasks;
using NLog;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OwinIdentitySimpleInjector.Middleware
{
    public class OwinDemoMiddleware
    {
        private AppFunc _next;
        private ILogger _logger = LogManager.GetLogger("OwinDemoMiddleware");

        public OwinDemoMiddleware(AppFunc next)
        {
            this._next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            _logger.Info("Owin type demo, Begin Request");
            await _next.Invoke(environment);
            _logger.Info("Owin type demo, End Request");
        }
    }
}