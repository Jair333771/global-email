using Global.Email.Application.Enumerations;

namespace Global.Email.Application.DTOs
{
    public class NetCoreUserDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
