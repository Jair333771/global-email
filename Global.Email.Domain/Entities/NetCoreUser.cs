using Global.Email.Application.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Global.Email.Domain.Entities
{
    [Table("netcore_users")]
    public class NetCoreUser : BaseEntity
    {
        [Column("user")]
        public string User { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
