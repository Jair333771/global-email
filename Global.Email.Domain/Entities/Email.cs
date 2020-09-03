using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global.Email.Domain.Entities
{
    [Table("email")]
    public class Email : BaseEntity
    {
        [Column("from_email")]
        public string FromEmail { get; set; }
        [Column("to_email")]
        public string ToEmail { get; set; }
        [Column("desc_message")]
        public string DescMessage { get; set; }
        [Column("date")]
        public DateTime? Date { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}