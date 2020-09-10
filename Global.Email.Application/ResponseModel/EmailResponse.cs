using Mandrill.Models;

namespace Global.Email.Application.ResponseModel
{
    public class EmailResponse
    {
        public string FromEmail { get; set; }
        public string Id { get; set; }
        public string RejectReason { get; set; }
        public EmailResultStatus Status { get; set; }
    }
}