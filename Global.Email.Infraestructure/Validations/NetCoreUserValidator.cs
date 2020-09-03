using FluentValidation;
using Global.Email.Application.RequestModel;

namespace Global.Email.Infraestructure.Validations
{
    class NetCoreUserValidator : BaseValidator<NetCoreUserRequest>
    {
        public NetCoreUserValidator()
        {
            RuleFor(x => x.User)
                .NotNull().WithMessage("El nombre requerido.")
                .NotEmpty().WithMessage("El nombre requerido.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("La contraseña requerida.")
                .NotEmpty().WithMessage("La contraseña requerida.");

            RuleFor(x => x.Role)
                .NotNull().WithMessage("El rol requerido.")
                .NotEmpty().WithMessage("El rol requerido.");
        }
    }
}
