// C#
using Xunit;
using Moq;
using BackendSRS.Application.Services;
using BackendSRS.Domain.Repositories;
using BackendSRS.Models;
using System.Collections.Generic;

public class InventarioServiceTests
{
    [Fact]
    public void GetInventario_DevuelveListaDispositivos()
    {
        // Arrange
        var dispositivos = new List<Dispositivos> { new Dispositivos { Nombre = "Disp1" } };
        var mockRepo = new Mock<IDispositivosRepository>();
        mockRepo.Setup(r => r.GetDispositivos()).Returns(dispositivos);

        var service = new InventarioService(mockRepo.Object);

        // Act
        var result = service.GetInventario();

        // Assert
        Assert.Single(result);
        Assert.Equal("Disp1", result[0].Nombre);
    }

    [Fact]
    public void AddDevice_LlamaAlRepositorioConDispositivoCorrecto()
    {
        // Arrange
        var mockRepo = new Mock<IDispositivosRepository>();
        var service = new InventarioService(mockRepo.Object);

        // Act
        service.AddDevice("Disp2", "Lab", "80", "Tablet");

        // Assert
        mockRepo.Verify(r => r.AddDevice(It.Is<Dispositivos>(d => d.Nombre == "Disp2" && d.Bateria == 80)), Times.Once);
    }

    [Fact]
    public void GetInventario_SinDispositivos_DevuelveListaVacia()
    {
        // Arrange
        var mockRepo = new Mock<IDispositivosRepository>();
        mockRepo.Setup(r => r.GetDispositivos()).Returns(new List<Dispositivos>());

        var service = new InventarioService(mockRepo.Object);

        // Act
        var result = service.GetInventario();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void AddDevice_BateriaNoValida_NoLlamaAlRepositorio()
    {
        // Arrange
        var mockRepo = new Mock<IDispositivosRepository>();
        var service = new InventarioService(mockRepo.Object);

        // Act
        service.AddDevice("Disp3", "Lab", "no-numero", "Tablet");

        // Assert
        mockRepo.Verify(r => r.AddDevice(It.IsAny<Dispositivos>()), Times.Never);
    }
}
