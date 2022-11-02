using AppLogin.Core.Entities;

namespace AppLogin.Business.Tests.Entities
{
    public class EmailValidatorTests
    {
        [Trait("AppLogin.Business.Entities", "EmailValidatorTests")]
        [Theory(DisplayName = "Ao criar um novo email, quando o texto passado como parametro nulo ou vazio, garantir lançamento de excepçao")]
        [InlineData(null)]
        [InlineData("")]
        public void GivenMakeNewEmail_WhenPassingStringEmailParameters_ThenEnsureEmailIsNotEmpty(string email)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => EmailValidator.Make(email));
        }

        [Trait("AppLogin.Business.Entities", "EmailValidatorTests")]
        [Fact(DisplayName = "Ao criar um novo email, o texto passado como parametro deve ser introduzido para a propriedade Email da classe EmailValidator")]
        public void GivenMakeNewEmail_WhenPassingStringEmailParameters_ThenEnsureSetParameterInProperties()
        {
            // Arrange
            var expectedEmail = "any_@email.com";

            // Act
            var result = EmailValidator.Make(expectedEmail);

            // Assert
            Assert.Equal(expectedEmail, result.Email);

        }

        [Trait("AppLogin.Business.Entities", "EmailValidatorTests")]
        [Fact(DisplayName = "Ao criar um novo email, quando este pertence ao dominio yahoo, deve garantir que este se encontra no formato correto")]
        public void GivemYahooValidation_WhenCreatingEmailValidator_ThenMustEnsureYahooEmailIsValid()
        {
            // Arrange
            var result = EmailValidator.Make("something@yahoo.com");

            // Act & Assert
            Assert.True(result.YahooValidate());
        }

        [Trait("AppLogin.Business.Entities", "EmailValidatorTests")]
        [Fact(DisplayName = "Ao criar um novo email, quando este pertence ao dominio google, deve garantir que este se encontra no formato correto")]
        public void GivemYahooValidation_WhenCreatingEmailValidator_ThenMustEnsureGoogleEmailIsValid()
        {
            // Arrange
            var result = EmailValidator.Make("something@google.com");

            // Act & Assert
            Assert.True(result.GoogleValidate());
        }




    }
}
