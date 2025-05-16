// C#
using Xunit;
using Moq;
using BackendSRS.Application.Services;
using BackendSRS.Domain.Entities.Models;
using BackendSRS.Domain.Repositories;
using System.Collections.Generic;
using BackendSRS.Models;

public class AlertasServiceTests
{
    [Fact]
    public void ObtenerAlertas_DevuelveLista()
    {
        // Arrange
        var alertas = new List<Alertas> { new Alertas { Mensaje = "Test", Criticidad = "Alta" } };
        var mockRepo = new Mock<IAlertasRepository>();
        mockRepo.Setup(r => r.ObtenerAlertas()).Returns(alertas);

        var service = new AlertasService(mockRepo.Object);

        // Act
        var result = service.ObtenerAlertas();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test", result[0].Mensaje);
    }

    [Fact]
    public void ObtenerAlertas_SinAlertas_DevuelveListaVacia()
    {
        // Arrange
        var mockRepo = new Mock<IAlertasRepository>();
        mockRepo.Setup(r => r.ObtenerAlertas()).Returns(new List<Alertas>());

        var service = new AlertasService(mockRepo.Object);

        // Act
        var result = service.ObtenerAlertas();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerarAlerta_LlamaAgregarAlerta()
    {
        // Arrange
        var mockRepo = new Mock<IAlertasRepository>();
        var service = new AlertasService(mockRepo.Object);

        // Act
        service.GenerarAlerta("Mensaje de prueba", "Media");

        // Assert
        mockRepo.Verify(r => r.AgregarAlerta(It.Is<Alertas>(a => a.Mensaje == "Mensaje de prueba" && a.Criticidad == "Media")), Times.Once);
    }

    [Fact]
    public void GenerarAlerta_MensajeVacio_NoLlamaAlRepositorio()
    {
        // Arrange
        var mockRepo = new Mock<IAlertasRepository>();
        var service = new AlertasService(mockRepo.Object);

        // Act
        service.GenerarAlerta("", "Alta");

        // Assert
        mockRepo.Verify(r => r.AgregarAlerta(It.IsAny<Alertas>()), Times.Never);
    }

    [Fact]
    public void GenerarAlerta_CriticidadNula_NoLlamaAlRepositorio()
    {
        // Arrange
        var mockRepo = new Mock<IAlertasRepository>();
        var service = new AlertasService(mockRepo.Object);

        // Act
        service.GenerarAlerta("Mensaje", null);

        // Assert
        mockRepo.Verify(r => r.AgregarAlerta(It.IsAny<Alertas>()), Times.Never);
    }

    [Fact]
    public void GenerarAlertaBateria_LlamaAgregarAlerta()
    {
        // Arrange
        var mockRepo = new Mock<IAlertasRepository>();
        var service = new AlertasService(mockRepo.Object);

        // Act
        service.GenerarAlertaBateria(1, 10);

        // Assert
        mockRepo.Verify(r => r.AgregarAlerta(It.Is<Alertas>(a => a.DispositivoId == 1 && a.Mensaje.Contains("batería"))), Times.Once);
    }

    [Fact]
    public void GenerarAlertaBateria_PorcentajeAlto_NoLlamaAlRepositorio()
    {

        // Arrange
        var mockRepo = new Mock<IAlertasRepository>();
        var service = new AlertasService(mockRepo.Object);

        // Act
        service.GenerarAlertaBateria(1, 90);

        // Assert
        mockRepo.Verify(r => r.AgregarAlerta(It.IsAny<Alertas>()), Times.Never);
    }
}
