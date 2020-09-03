using Global.Email.Application.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Global.Email.Application.RequestModel
{
    public class NetCoreUserRequest
    {
        public int Id { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El usuario es requerido", AllowEmptyStrings = false)]
        public string User { get; set; }

        public string UserName { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "La contraseña es requerida", AllowEmptyStrings = false)]
        public string Password { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El Rol es requerido", AllowEmptyStrings = false)]
        public RoleType? Role { get; set; }
    }
}
