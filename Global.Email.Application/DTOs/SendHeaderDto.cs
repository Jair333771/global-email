using System;

namespace Global.Email.Application.DTOs
{
    public class SendHeaderDto
    {
        public int Id { get; set; }        
        public int? ApplicationId { get; set; }
        public int? SubApplicationId { get; set; }
        public string ByName { get; set; }
        public string ByEmail { get; set; }
        public string DescSubject { get; set; }
        public DateTime? SendDate { get; set; }
        public string SendUser { get; set; }
        public string ForMail { get; set; }
        public string ForMailCc { get; set; }
        public string ForMailBcc { get; set; }
        public int? ProcessId { get; set; }
        public int? SubProcessId { get; set; }
        public int? TemplateId { get; set; }
        public int? SnComplete { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? SnInProcess { get; set; }
        public DateTime? SchedulingDate { get; set; }
        public bool? SnMassive { get; set; }
    }
}
