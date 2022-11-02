using AppLogin.Business.UseCases;
using AppLogin.Core.Contracts;
using AppLogin.Core.Entities;
using AppLogin.Core.UseCases;
using Moq;
using Xunit;

namespace AppLogin.Business.Tests.UseCases
{
    public class FazerLoginTests
    {
        [Trait("AppLogin.Business.UseCases", "FazerLoginTests")]
        [Theory(DisplayName = "Ao Fazer Login, Quando Parametros Entrada Invalidos, Entao Lancar Exception")]
        [InlineData("", "")]
        [InlineData("teste", "")]
        [InlineData("teste@", "")]
        [InlineData(null, "")]
        [InlineData("teste@teste.com", "12345")]
        public async Task AoFazerLogin_QuandoParametrosEntradaInvalidos_EntaoLancarException(string email, string senha)
        {
            // Arrange
            var sut = new FazerLogin();

            // Act
            var result = await sut.Handle(new FazerLoginCommand { Email = email, Senha = senha });

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsOk);
            Assert.NotNull(result.data);
        }

        [Trait("AppLogin.Business.UseCases", "FazerLoginTests")]
        [Theory(DisplayName = "Ao Fazer Login, Quando Email Nao Authorizado, Email Deve ser isValid = false ")]
        [InlineData("teste@outlook.com")]
        public async Task AoFazerLogin_QuandoEmailNaoAuthorizado_EmailDeveRetornarInvalido(string email)
        {
            // Arrange
            var sut = new FazerLogin();

            // Act
            var result = await sut.Handle(new FazerLoginCommand { Email = email, Senha = "123456" });

            // Assert
            Assert.False(result.IsOk);

        }
    }
}