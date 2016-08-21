using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLog;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OwinIdentitySimpleInjector.Middleware
{
    public class LogginMiddleware
    {
        private AppFunc _next;
        private ILogger _logger;

        public void Initialize(AppFunc next, ILogger logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            _logger.Info("Owin instance demo, Begin Request");
            await _next.Invoke(environment);
            _logger.Info("Owin instance demo, End Request");
        }
    }
}