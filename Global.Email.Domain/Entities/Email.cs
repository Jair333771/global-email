using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Email.Domain.Entities
{
    public class Email : BaseEntity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}