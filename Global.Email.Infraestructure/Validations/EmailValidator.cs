using FluentValidation;
using Global.Email.Application.RequestModel;
using System;

namespace Global.Email.Infraestructure.Validations
{
    public class EmailValidator : AbstractValidator<EmailRequest>
    {
        public EmailValidator()
        {
            RuleFor(email => email.From)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("El correo no es válido.")
                .EmailAddress().WithMessage("El remitente no es válido.")
                .NotNull().WithMessage("El remitente del correo es requerido.")
                .NotEmpty().WithMessage("El remitente del correo no puede estar vacio.");


            RuleFor(email => email.To)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("El correo no es válido.")
                .EmailAddress().WithMessage("El destinatario no es válido.")
                .NotNull().WithMessage("El destinatario del correo es requerido.")
                .NotEmpty().WithMessage("El destinatario no puede estar vacio.");

            RuleFor(email => email.Message)
                .NotNull().WithMessage("El mensaje es requerido.")
                .NotEmpty().WithMessage("El mensaje no puede estar vacio.");
        }
    }
}
