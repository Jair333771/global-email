using Global.Email.Application.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Global.Email.Application.RequestModel
{
    public class NetCoreUserRequest
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string User { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El Rol es requerido")]
        public RoleType? Role { get; set; }
    }
}
