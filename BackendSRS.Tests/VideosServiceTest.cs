// C#
using Xunit;
using Moq;
using BackendSRS.Application.Services;
using BackendSRS.Domain.Repositories;
using BackendSRS.Models;
using System.Collections.Generic;

public class VideosServiceTests
{
    [Fact]
    public void GetVideos_DevuelveListaVideos()
    {
        // Arrange
        var videos = new List<Videos> { new Videos { RutaVideo = "Video1.mp4" } };
        var mockRepo = new Mock<IVideosRepository>();
        mockRepo.Setup(r => r.GetVideos()).Returns(videos);

        var service = new VideosService(mockRepo.Object);

        // Act
        var result = service.GetVideos();

        // Assert
        Assert.Single(result);
        Assert.Equal("Video1.mp4", result[0].RutaVideo);
    }
}
