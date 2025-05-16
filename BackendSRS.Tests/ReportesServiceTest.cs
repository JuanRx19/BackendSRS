// C#
using Xunit;
using Moq;
using BackendSRS.Application.Services;
using BackendSRS.Domain.Repositories;
using BackendSRS.Domain.Entities.Models;
using System.Collections.Generic;

public class ReportesServiceTests
{
    [Fact]
    public void ObtenerReportes_RetornaListaDeReportes()
    {
        // Arrange
        var mockRepo = new Mock<IReporteRepository>();
        var reportesEsperados = new List<ReportesDetalle>
        {
            new ReportesDetalle { /* inicializa propiedades si quieres */ }
        };
        mockRepo.Setup(r => r.ObtenerReportes()).Returns(reportesEsperados);

        var servicio = new ReportesService(mockRepo.Object);

        // Act
        var resultado = servicio.ObtenerReportes();

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(reportesEsperados, resultado);
    }

    [Fact]
    public void ObtenerReportes_SinReportes_DevuelveListaVacia()
    {
        // Arrange
        var mockRepo = new Mock<IReporteRepository>();
        mockRepo.Setup(r => r.ObtenerReportes()).Returns(new List<ReportesDetalle>());

        var servicio = new ReportesService(mockRepo.Object);

        // Act
        var resultado = servicio.ObtenerReportes();

        // Assert
        Assert.Empty(resultado);
    }
}
