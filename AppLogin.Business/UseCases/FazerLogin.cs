using AppLogin.Core.Entities;
using AppLogin.Core.UseCases;

namespace AppLogin.Business.UseCases
{
    public class FazerLogin : IFazerLogin
    {
        public Task<FazerLoginResult> Handle(FazerLoginCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return Task.FromResult(new FazerLoginResult(false, command.Notifications.Select(x => new {x.Message, x.Property}).ToArray()));

            var emailValidator =  EmailValidator.Make(command.Email);
            emailValidator.ValidateOperator();

            return Task.FromResult(new FazerLoginResult(emailValidator.isValid, command.Notifications.Select(x => new { x.Message, x.Property }).ToArray()));
        }
    }
}