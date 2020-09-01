using FluentValidation;
using Global.Email.Domain.Entities;

namespace Global.Email.Infraestructure.Validations
{
    class SendHeaderDetailValidator : BaseValidator<SendHeaderDetail>
    {
        public SendHeaderDetailValidator()
        {
            RuleFor(X => X.SendHeaderId)
                .GreaterThan(0).WithMessage("El id no es válido.");

            RuleFor(X => X.ApiId)
                .NotNull().WithMessage("El api id es requerido.");

            RuleFor(X => X.FromEmail)
                .Matches(EmailRegex)
                .WithMessage("El correo remitente no es válido.")
                .EmailAddress().WithMessage("El remitente no es válido.")
                .NotNull().WithMessage("El remitente del correo es requerido.")
                .NotEmpty().WithMessage("El remitente del correo no puede estar vacio.");

            RuleFor(X => X.ConfirmDate);

            RuleFor(X => X.ReturnDate);

            RuleFor(X => X.StatusCode);

            RuleFor(X => X.DescState);

            RuleFor(X => X.DetailState);

            RuleFor(X => X.DestinationTypeId)
                .NotNull().WithMessage("El valor de destinación es válido.")
                .GreaterThan(0).WithMessage("El id no es válido.");

            RuleFor(X => X.PersonId)
                .NotNull().WithMessage("El id de persona es requerido.")
                .GreaterThan(0).WithMessage("El id no es válido.");

            RuleFor(X => X.PvCeroId)
                .NotNull().WithMessage("El pv cero id es requerido.")
                .GreaterThan(0).WithMessage("El pv cero id no es válido.");

            RuleFor(X => X.CreationDate);

            RuleFor(X => X.DetailId)
                .NotNull().WithMessage("El id de detalle es requerido.")
                .GreaterThan(0).WithMessage("El id de detalle no es válido.");

            RuleFor(X => X.SnInProceso);

            RuleFor(X => X.PqCode)
               .NotNull().WithMessage("El codigo pq es requerido.")
               .GreaterThan(0).WithMessage("El  codigo pq no es válido.");

            RuleFor(X => X.AvanceCode)
              .NotNull().WithMessage("El codigo pq es requerido.")
              .GreaterThan(0).WithMessage("El  codigo pq no es válido.");

            RuleFor(X => X.NumberOperations)
              .NotNull().WithMessage("El número de operaciones es requerido.")
              .GreaterThan(0).WithMessage("El  codigo pq no es válido.");
        }
    }
}