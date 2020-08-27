using System;

namespace Global.Email.Application.RequestModel
{
    public class EmailRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public DateTime? Date => DateTime.Now;
    }
}