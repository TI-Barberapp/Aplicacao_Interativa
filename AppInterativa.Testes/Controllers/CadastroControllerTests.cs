using Aplicacao_Interativa.Controllers;
using Aplicacao_Interativa.Enums;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AppInterativa.Testes.Controllers
{
    public class CadastroControllerTests
    {
        [Fact]
        public void TestarCriar_QuandoUsuarioForValido()
        {
            // Arrange
            var usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            var tempDataMock = new Mock<ITempDataDictionary>();
            

            var novoUsuario = new UsuarioModel
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Celular = "123456789",
                Senha = "teste123",
                Perfil = PerfilEnum.Cliente
            };

            // Act
            var resultado = controller.Criar(novoUsuario) as RedirectToActionResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Index", resultado.ActionName);
            Assert.Equal("Login", resultado.ControllerName);
            tempDataMock.VerifySet(tempData => tempData["MensagemSucesso"] = "O cadastro foi feito com sucesso.", Times.Once);
            usuarioRepositorioMock.Verify(repo => repo.Adicionar(novoUsuario), Times.Once);
        }

        [Fact]
        public void TestarCriar_QuandoUsuarioForInvalido()
        {
            // Arrange
            var usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            var tempDataMock = new Mock<ITempDataDictionary>();
            var controller = new CadastroController(usuarioRepositorioMock.Object)
            {
                TempData = tempDataMock.Object
            };

            var usuarioInvalido = new UsuarioModel();

            // Act
            var resultado = controller.Criar(usuarioInvalido) as RedirectToActionResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Criar", resultado.ActionName);
            Assert.Equal("Cadastro", resultado.ControllerName);
            usuarioRepositorioMock.Verify(repo => repo.Adicionar(It.IsAny<UsuarioModel>()), Times.Never);
        }

        [Fact]
        public void TestarCriar_QuandoEmailForDuplicado()
        {
            // Arrange
            var usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            var tempDataMock = new Mock<ITempDataDictionary>();
            var controller = new CadastroController(usuarioRepositorioMock.Object)
            {
                TempData = tempDataMock.Object
            };

            var novoUsuario = new UsuarioModel
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Celular = "123456789",
                Senha = "teste123",
                Perfil = PerfilEnum.Cliente
            };

            usuarioRepositorioMock.Setup(repo => repo.BuscarPorLogin(novoUsuario.Email))
                                  .Returns(new UsuarioModel());

            // Act
            var resultado = controller.Criar(novoUsuario) as RedirectToActionResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Criar", resultado.ActionName);
            Assert.Equal("Cadastro", resultado.ControllerName);
            tempDataMock.VerifySet(tempData => tempData["MensagemErro"] = "Esse e-mail já está sendo utilizado.", Times.Once);
            usuarioRepositorioMock.Verify(repo => repo.Adicionar(It.IsAny<UsuarioModel>()), Times.Never);
        }
    }
}
