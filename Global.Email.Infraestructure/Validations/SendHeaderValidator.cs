using FluentValidation;
using Global.Email.Domain.Entities;

namespace Global.Email.Infraestructure.Validations
{
    public class SendHeaderValidator : BaseValidator<SendHeader>
    {
        public SendHeaderValidator()
        {
            RuleFor(X => X.ApplicationId)
                .NotEmpty().WithMessage("El id de aplicación es requerido.")
                .NotNull().WithMessage("El id de aplicación es requerido.")
                .GreaterThan(0).WithMessage("El id de aplicación no es válido.");

            RuleFor(X => X.SubApplicationId)
                .NotEmpty().WithMessage("El id de subaplicación es requerido.")
                .NotNull().WithMessage("El id de subaplicación es requerido.")
                .GreaterThan(0).WithMessage("El id de subaplicación no es válido.");

            RuleFor(X => X.ByName)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .NotNull().WithMessage("El nombre es requerido.");

            RuleFor(x => x.ByEmail)
                .Matches(EmailRegex).WithMessage("El correo remitente no es válido.")
                .EmailAddress().WithMessage("El remitente no es válido.")
                .NotNull().WithMessage("El remitente del correo es requerido.")
                .NotEmpty().WithMessage("El remitente del correo no puede estar vacio.");

            RuleFor(X => X.DescSubject)
                .NotEmpty().WithMessage("La descripción es requerida.")
                .NotNull().WithMessage("La descripción es requerida.");

            RuleFor(x => x.SendUser)
                .NotEmpty().WithMessage("El usuario es requerido.")
                .NotNull().WithMessage("El usuario es requerido.");

            RuleFor(x => x.ForMail)
                .Matches(EmailRegex).WithMessage("El correo destinatario no es válido.")
                .EmailAddress().WithMessage("El destinatario no es válido.")
                .NotNull().WithMessage("El destinatario del correo es requerido.")
                .NotEmpty().WithMessage("El destinatario del correo no puede estar vacio.");

            RuleFor(x => x.ForMailCc)
                .Matches(EmailRegex)
                .WithMessage("El correo copia no es válido.");

            RuleFor(x => x.ForMailBcc)
                .Matches(EmailRegex)
                .WithMessage("El correo copia oculta no es válido.");

            RuleFor(x => x.ProcessId)
                .NotEmpty().WithMessage("El id de proceso es requerido.")
                .NotNull().WithMessage("El id de proceso es requerido.")
                .NotEmpty().GreaterThan(0).WithMessage("El id de proceso no es válido.");

            RuleFor(x => x.SubProcessId)
                .NotEmpty().WithMessage("El id de subproceso es requerido.")
                .NotNull().WithMessage("El id de subproceso es requerido.")
                .NotEmpty().GreaterThan(0).WithMessage("El id del subproceso no es válido.");

            RuleFor(x => x.TemplateId)
                .NotEmpty().WithMessage("El id de la plantilla es requerido.")
                .NotNull().WithMessage("El id de la plantilla es requerido.")
                .NotEmpty().GreaterThan(0).WithMessage("El id de la plantilla no es válido.");

            RuleFor(x => x.SendDate);

            RuleFor(x => x.SnComplete);

            RuleFor(x => x.CreationDate);

            RuleFor(x => x.SnInProcess);

            RuleFor(x => x.SchedulingDate);

            RuleFor(x => x.SnMassive);
        }
    }
}