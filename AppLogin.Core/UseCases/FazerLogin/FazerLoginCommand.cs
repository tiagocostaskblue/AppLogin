using Flunt.Notifications;
using Flunt.Validations;

namespace AppLogin.Core.UseCases
{
    public class FazerLoginCommand : Notifiable
    {
        public string Email { get; init; }
        public string Senha { get; init; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Email,nameof(Email),"Email não pode ser nulo ou vazio")
                .IsNotNullOrEmpty(Senha,nameof(Senha),"Email não pode ser nulo ou vazio")
                .IsEmail(Email,nameof(Email), "Email inválido")
                .IsGreaterThan(Senha.Length, 5, nameof(Senha), "Senha inválida")
            );
        }
    }
}