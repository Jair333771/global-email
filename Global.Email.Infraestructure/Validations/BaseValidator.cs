using FluentValidation;
using System.Text.RegularExpressions;

namespace Global.Email.Infraestructure.Validations
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        public Regex EmailRegex { get; set; }

        public BaseValidator()
        {
            EmailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
    }
}