using System;

namespace Global.Email.Application.DTOs
{
    public class SendHeaderDto
    {
        public int? Application_id { get; set; }
        public int? Sub_application_id { get; set; }
        public string By_name { get; set; }
        public string By_email { get; set; }
        public string Desc_subject { get; set; }
        public DateTime? Send_date { get; set; }
        public string Send_user { get; set; }
        public string For_mail { get; set; }
        public string For_mail_Cc { get; set; }
        public string For_mail_Bcc { get; set; }
        public int? Process_id { get; set; }
        public int? Sub_process_id { get; set; }
        public int? Template_id { get; set; }
        public int? Sn_complete { get; set; }
        public DateTime? Creation_date { get; set; }
        public int? Sn_int_process { get; set; }
        public DateTime? Scheduling_date { get; set; }
        public bool? Sn_massive { get; set; }
    }
}
