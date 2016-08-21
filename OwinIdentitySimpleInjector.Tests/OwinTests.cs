using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Tests
{
    [TestClass]
    public class OwinTests
    {
        [TestMethod]
        public async Task OwinAppTest()
        {
            using (var server = TestServer.Create(app =>
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello world using OWIN TestServer");
                });
            }))
            {
                HttpResponseMessage response = await server.CreateRequest("/").AddHeader("header1", "headervalue1").GetAsync();

                //Execute necessary tests
                Assert.AreEqual("Hello world using OWIN TestServer", await response.Content.ReadAsStringAsync());
            }
        }
    }
}
