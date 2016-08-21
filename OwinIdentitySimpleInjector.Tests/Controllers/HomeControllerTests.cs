using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwinIdentitySimpleInjector.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests : HttpContextTest
    {
        private HomeController _homeController;

        [TestInitialize]
        public void SetUp()
        {
            _homeController = new HomeController();
        }

        [TestMethod]
        public void Authenticated_MockOwinContext_ReturnIfAuthneticatedCorrectView()
        {
            // Arrange
            var context = GetMockedHttpContext();

            // Act

            // Assert
        }
    }
}
