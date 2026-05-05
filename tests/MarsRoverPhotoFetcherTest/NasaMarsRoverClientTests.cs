using MarsRoverPhotoFetcher.Models;
using MarsRoverPhotoFetcher.Services.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class NasaMarsRoverClientTests
{
    [Fact]
    public async Task GetPhotosAsync_ReturnsExpectedData_WhenApiRespondsSuccessfully()
    {
        // A small, realistic JSON snippet similar to what NASA returns.
        var apiResponse = """
        {
            "photos": [
                {
                    "id": 7,
                    "img_src": "http://example.com/test-image.jpg"
                }
            ]
        }
        """;

        // Mock HttpMessageHandler so HttpClient returns our fake payload.
        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(apiResponse)
            });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://api.nasa.gov/")
        };

        // Mock the other dependencies your constructor requires.
        var loggerMock = new Mock<ILogger<NasaMarsRoverClient>>();

        var optionsMock = new Mock<IOptions<NasaOptions>>();
        optionsMock.Setup(o => o.Value).Returns(new NasaOptions
        {
            ApiKey = "TEST_KEY"
        });

        var envMock = new Mock<IWebHostEnvironment>();
        envMock.Setup(e => e.ContentRootPath).Returns(Directory.GetCurrentDirectory());

        // Create the client with all required dependencies.
        var client = new NasaMarsRoverClient(
            httpClient,
            loggerMock.Object,
            optionsMock.Object,
            envMock.Object
        );

        // Act
        var result = await client.GetPhotosByEarthDateAsync(new DateTime(2017, 2, 27));

        // Assert
        Assert.NotNull(result);

        var photo = result.FirstOrDefault();
        Assert.Equal(7, photo.Id);
        Assert.Equal("http://example.com/test-image.jpg", photo.Img_Src);
    }
}
