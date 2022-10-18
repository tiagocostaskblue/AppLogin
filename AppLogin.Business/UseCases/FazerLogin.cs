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
                
            
            
            
            throw new NotImplementedException();
        }
    }
}