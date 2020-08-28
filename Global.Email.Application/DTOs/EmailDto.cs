using System;

namespace Global.Email.Application.DTOs
{
    public class EmailDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
