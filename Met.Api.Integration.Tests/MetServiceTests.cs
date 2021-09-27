using MET.Api.Integration.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Met.Api.Integration.Tests
{
    public class MetServiceTests
    {
        private readonly MetService _sut;

        public MetServiceTests()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var client = new HttpClient();
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            _sut = new MetService(mockFactory.Object);
        }

        [Fact]
        public async Task GetLocationForecast_ShouldReturnForecastResponseModel()
        {
            // Arrange
            var latitude = "54.09939";
            var longitude = "32.0487";

            // Act
            var weatherForecast = await _sut.GetLocationForecast(latitude, longitude);

            // Assert
            Assert.NotNull(weatherForecast);

        }
    }
}
