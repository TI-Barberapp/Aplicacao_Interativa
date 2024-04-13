using Aplicacao_Interativa.Controllers;
using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Enums;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace AppInterativa.Testes.Controllers
{
    public class LoginControllerTests
    {
        private LoginController _controller;
        private Mock<ISessao> _sessaoMock;
        private Mock<IEmail> _emailMock;
        private Mock<IUsuarioRepositorio> _usuarioRepositorioMock;

        public LoginControllerTests()
        {
            _sessaoMock = new Mock<ISessao>();
            _emailMock = new Mock<IEmail>();
            _usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            _controller = new LoginController(_sessaoMock.Object, _emailMock.Object, _usuarioRepositorioMock.Object);
        }

        [Fact]
        public void Entrar_QuandoModeloInvalido()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Email = "",
                Senha = ""
            };

            // Act
            var result = _controller.Entrar(loginModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void EsqueciSenha_QuandoEmailNaoExistente()
        {
            // Arrange
            var email = "email@naoexistente.com";
            var redefinirSenhaModel = new EsqueciSenhaModel { Email = email };
            UsuarioModel usuario = new UsuarioModel { Email = "" };

            _usuarioRepositorioMock.Setup(repo => repo.BuscarPorLogin(email)).Returns(usuario);

            // Act
            var result = _controller.EsqueciSenha(redefinirSenhaModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("EsqueciSenha", result.ActionName);
            Assert.Equal("Login", result.ControllerName);
        }

        [Fact]
        public void RedefinirSenha_QuandoEntradaValida()
        {
            // Arrange
            var redefinirSenhaModel = new RedefinirSenhaModel
            {
                Usuario = 1,
                NovaSenha = "novaSenha123"
            };
            var usuarioExistente = new UsuarioModel { Id = 1, Nome = "Teste" };

            _usuarioRepositorioMock.Setup(repo => repo.RecuperarPeloId(redefinirSenhaModel.Usuario)).Returns(usuarioExistente);

            // Act
            var result = _controller.RedefinirSenha(redefinirSenhaModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Login", result.ControllerName);

            _usuarioRepositorioMock.Verify(repo => repo.SalvarNovaSenha(usuarioExistente, redefinirSenhaModel.NovaSenha), Times.Once);
        }
    }   
    
}
