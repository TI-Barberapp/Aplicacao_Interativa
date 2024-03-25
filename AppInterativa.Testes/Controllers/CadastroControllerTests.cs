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
        public void Criar_Should_Return_RedirectToAction_When_Model_Is_Valid()
        {
            // Arrange
            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            var mockTempData = new Mock<ITempDataDictionary>();
            var controller = new CadastroController(mockUsuarioRepositorio.Object)
            {
                TempData = mockTempData.Object
            };

            var usuario = new UsuarioModel
            {
                Id = 1,
                Nome = "David",
                Email = "david@gmail.com",
                Celular = "31 994706649",
                Senha = "1234",
                Perfil = PerfilEnum.Barbeiro
            };

            controller.ModelState.AddModelError("FakeError", "This is a fake error message.");
            // Act
            var result = controller.Criar(usuario) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Login", result.ControllerName);
        }
    }
}
