using FluentValidation;
using Global.Email.Application.RequestModel;

namespace Global.Email.Infraestructure.Validations
{
    class SendHeaderDetailValidator : BaseValidator<SendHeaderDetailRequest>
    {   
        public SendHeaderDetailValidator()
        {
            RuleFor(x => x.SendHeaderId)
                .GreaterThan(0)
                .WithMessage("El sendHeaderId es requerido.");

            RuleFor(X => X.ApiId)
                .NotEmpty().WithMessage("El api id es requerido.")
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
                .GreaterThan(x => x.DestinationTypeId.GetValueOrDefault())
                .When(x => x.DestinationTypeId.HasValue)
                .OverridePropertyName("DestinationTypeId").WithMessage("El id no es válido.");

            RuleFor(X => X.PersonId)
                .GreaterThan(x => x.PersonId.GetValueOrDefault())
                .When(x => x.PersonId.HasValue)
                .OverridePropertyName("PersonId").WithMessage("El id no es válido.");

            RuleFor(X => X.PvCeroId)
                .GreaterThan(x => x.PvCeroId.GetValueOrDefault())
                .When(x => x.PvCeroId.HasValue)
                .OverridePropertyName("PvCeroId").WithMessage("El pv cero id no es válido.");

            RuleFor(X => X.DetailId)
                .GreaterThan(x => x.DetailId.GetValueOrDefault())
                .When(x => x.DetailId.HasValue)
                .OverridePropertyName("DetailId").WithMessage("El id de detalle no es válido.");

            RuleFor(X => X.SnInProcess);

            RuleFor(X => X.PqCode)
                .GreaterThan(x => x.PqCode.GetValueOrDefault())
                .When(x => x.PqCode.HasValue)
                .OverridePropertyName("PqCode").WithMessage("El  codigo pq no es válido.");

            RuleFor(X => X.AvanceCode)
                .GreaterThan(x => x.AvanceCode.GetValueOrDefault())
                .When(x => x.AvanceCode.HasValue)
                .OverridePropertyName("AvanceCode").WithMessage("El  codigo pq no es válido.");

            RuleFor(X => X.NumberOperations)
                .GreaterThan(x => x.NumberOperations.GetValueOrDefault())
                .When(x => x.NumberOperations.HasValue)
                .OverridePropertyName("NumberOperations").WithMessage("El  codigo pq no es válido.");
        }
    }
}