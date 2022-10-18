using AppLogin.Business.UseCases;
using AppLogin.Core.UseCases;

namespace AppLogin.Business.Tests.UseCases
{
    public class FazerLoginTests
    {
        [Trait("AppLogin.Business.UseCases", "FazerLoginTests")]
        [Theory(DisplayName = "AoFazerLogin_QuandoParametrosEntradaInvalidos_EntaoLancarException")]
        [InlineData("", "")]
        [InlineData("teste", "")]
        [InlineData("teste@", "")]
        [InlineData(null, "")]
        [InlineData(null, "")]
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
    }
}