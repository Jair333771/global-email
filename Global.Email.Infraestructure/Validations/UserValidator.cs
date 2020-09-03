using FluentValidation;
using Global.Email.Application.RequestModel;

namespace Global.Email.Infraestructure.Validations
{
    class UserValidator : BaseValidator<NetCoreUserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.User)
                .NotNull().WithMessage("El nombre requerido.")
                .NotEmpty().WithMessage("El nombre requerido.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("La contraseña requerida.")
                .NotEmpty().WithMessage("La contraseña requerida.");
        }
    }
}
