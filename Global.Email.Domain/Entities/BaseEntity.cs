using System.ComponentModel.DataAnnotations;

namespace Global.Email.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}