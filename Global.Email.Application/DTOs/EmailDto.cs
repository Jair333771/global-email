using System;

namespace Global.Email.Application.DTOs
{
    public class EmailDto
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string DescMessage { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}