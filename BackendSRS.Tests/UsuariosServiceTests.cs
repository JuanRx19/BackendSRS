// C#
using Xunit;
using Moq;
using BackendSRS.Application.Services;
using BackendSRS.Domain.Interfaces;
using BackendSRS.Domain.Repositories;
using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UsuariosServiceTests
{
    [Fact]
    public async Task CreateUsuario_CreaUsuarioCorrectamente()
    {
        // Arrange
        var mockRepo = new Mock<IUsuarioRepository>();
        var mockEncript = new Mock<IEncriptacionService>();
        mockEncript.Setup(e => e.Encriptar(It.IsAny<string>())).Returns("hashed");
        mockRepo.Setup(r => r.CreateUsuario(It.IsAny<Usuarios>())).Returns(Task.CompletedTask);

        var service = new UsuariosService(mockRepo.Object, mockEncript.Object);

        // Act
        await service.CreateUsuario("Juan", "juan@mail.com", "1234", 1, DateTime.Now);

        // Assert
        mockRepo.Verify(r => r.CreateUsuario(It.Is<Usuarios>(u => u.Password == "hashed")), Times.Once);
    }

    [Fact]
    public void VerificarInicioSesion_UsuarioYPasswordCorrectos_DevuelveTrue()
    {
        // Arrange
        var usuario = new Usuarios { Email = "test@mail.com", Password = "hashed" };
        var mockRepo = new Mock<IUsuarioRepository>();
        var mockEncript = new Mock<IEncriptacionService>();
        mockRepo.Setup(r => r.ObtenerUsuarioPorEmail("test@mail.com")).Returns(usuario);
        mockEncript.Setup(e => e.VerificarPassword("1234", "hashed")).Returns(true);

        var service = new UsuariosService(mockRepo.Object, mockEncript.Object);

        // Act
        var result = service.VerificarInicioSesion("test@mail.com", "1234");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetUsuarios_DevuelveListaUsuarios()
    {
        // Arrange
        var usuarios = new List<Usuarios> { new Usuarios { Nombre = "A" } };
        var mockRepo = new Mock<IUsuarioRepository>();
        var mockEncript = new Mock<IEncriptacionService>();
        mockRepo.Setup(r => r.GetUsuarios()).Returns(usuarios);

        var service = new UsuariosService(mockRepo.Object, mockEncript.Object);

        // Act
        var result = service.GetUsuarios();

        // Assert
        Assert.Single(result);
        Assert.Equal("A", result[0].Nombre);
    }

    [Fact]
    public void VerificarInicioSesion_UsuarioNoExiste_DevuelveFalse()
    {
        // Arrange
        var mockRepo = new Mock<IUsuarioRepository>();
        var mockEncript = new Mock<IEncriptacionService>();
        mockRepo.Setup(r => r.ObtenerUsuarioPorEmail("noexiste@mail.com")).Returns((Usuarios)null);

        var service = new UsuariosService(mockRepo.Object, mockEncript.Object);

        // Act
        var result = service.VerificarInicioSesion("noexiste@mail.com", "1234");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void VerificarInicioSesion_PasswordIncorrecto_DevuelveFalse()
    {
        // Arrange
        var usuario = new Usuarios { Email = "test@mail.com", Password = "hashed" };
        var mockRepo = new Mock<IUsuarioRepository>();
        var mockEncript = new Mock<IEncriptacionService>();
        mockRepo.Setup(r => r.ObtenerUsuarioPorEmail("test@mail.com")).Returns(usuario);
        mockEncript.Setup(e => e.VerificarPassword("incorrecto", "hashed")).Returns(false);

        var service = new UsuariosService(mockRepo.Object, mockEncript.Object);

        // Act
        var result = service.VerificarInicioSesion("test@mail.com", "incorrecto");

        // Assert
        Assert.False(result);
    }
}
