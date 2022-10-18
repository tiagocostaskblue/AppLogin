namespace AppLogin.Core.UseCases
{
    public interface IFazerLogin
    {
        Task<FazerLoginResult> Handle(FazerLoginCommand command);
    }
}