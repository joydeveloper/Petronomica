using Petronomica.Controllers;
using Microsoft.AspNetCore.Mvc;

using Xunit;
using Petronomica;
using System.Net.Http;
using System.Threading.Tasks;
using ReUse;
using System.IO;
using Microsoft.Extensions.Logging;

namespace XUnitTestPetronomica
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            var controller = new DevelopmentController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
        public class PrimeService_IsPrimeShould
        {
            private readonly PrimeService _primeService;

            public PrimeService_IsPrimeShould()
            {
                _primeService = new PrimeService();
            }

            [Fact]
            public void ReturnFalseGivenValueOf1()
            {
                var result = _primeService.IsPrime(0);

                Assert.False(result, "1 should not be prime");
            }
        }
        //    public class BasicTests
        //  : IClassFixture<CustomWebPagesApplicationFactory<Startup>>
        //    {
        //        private readonly CustomWebPagesApplicationFactory<Startup> _factory;

        //        public BasicTests(CustomWebPagesApplicationFactory<Startup> factory)
        //        {
        //            _factory = factory;
        //        }

        //        [Theory]
        //        [InlineData("/")]
        //        [InlineData("/Index")]
        //        //[InlineData("/About")]
        //        //[InlineData("/Privacy")]
        //        //[InlineData("/Contact")]
        //        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        //        {
        //            // Arrange
        //            var client = _factory.CreateClient();

        //            // Act
        //            var response = await client.GetAsync(url);

        //            // Assert
        //            response.EnsureSuccessStatusCode(); // Status Code 200-299
        //            Assert.Equal("text/html; charset=utf-8",
        //                response.Content.Headers.ContentType.ToString());
        //        }
        //    }
        //}
    }
}
