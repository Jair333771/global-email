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
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("El remitente del correo es requerido.");

            RuleFor(email => email.To)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("El destinatario del correo es requerido.");

            RuleFor(email => email.Message)
               .NotNull()
               .NotEmpty()
               .WithMessage("El mensaje es requerido.");
        }
    }
}
