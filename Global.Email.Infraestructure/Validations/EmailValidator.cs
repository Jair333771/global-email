using FluentValidation;
using Global.Email.Application.RequestModel;

namespace Global.Email.Infraestructure.Validations
{
    public class EmailValidator : BaseValidator<EmailRequest>
    {
        public EmailValidator()
        {
            RuleFor(email => email.FromEmail)
                .Matches(EmailRegex).WithMessage("El correo no es válido.")
                .EmailAddress().WithMessage("El remitente no es válido.")
                .NotNull().WithMessage("El remitente del correo es requerido.")
                .NotEmpty().WithMessage("El remitente del correo no puede estar vacio.");


            RuleFor(email => email.ToEmail)
                .Matches(EmailRegex).WithMessage("El correo no es válido.")
                .EmailAddress().WithMessage("El destinatario no es válido.")
                .NotNull().WithMessage("El destinatario del correo es requerido.")
                .NotEmpty().WithMessage("El destinatario no puede estar vacio.");

            RuleFor(email => email.DescMessage)
                .NotNull().WithMessage("El mensaje es requerido.")
                .NotEmpty().WithMessage("El mensaje no puede estar vacio.");
        }
    }
}