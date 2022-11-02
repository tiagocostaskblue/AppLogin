using AppLogin.Core.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System.Text.RegularExpressions;

namespace AppLogin.Core.Entities
{
    public class EmailValidator : IYahooProviderForLogin, IGoogleProviderForLogin
    {
        //private IList<bool> _hasErrors;
        //public bool HasError => _hasErrors.Any();
        public bool isValid = false;
        public string Email { get; }

        private EmailValidator(string email)
        {
            //this._hasErrors = new List<bool>();
            this.Email = email; 
        }

        public static EmailValidator Make(string email)
        {
            if(string.IsNullOrEmpty(email))
                throw new ArgumentNullException();

            return new EmailValidator(email);
        }

        public bool YahooValidate()
        {
            return Regex.IsMatch(Email, @"@yahoo.com$");
        }

        public bool GoogleValidate()
        {
            return Regex.IsMatch(Email, @"@google.com$");
        }

        public void ValidateOperator()
        {
            if(GoogleValidate() || YahooValidate())
                isValid = true;

            else isValid = false;
        }
    }
}
