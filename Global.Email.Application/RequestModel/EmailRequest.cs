using System;

namespace Global.Email.Application.RequestModel
{
    public class EmailRequest
    {
        public int Id { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string DescMessage { get; set; }
        public DateTime? Date => DateTime.Now;
    }
}