using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global.Email.Domain.Entities
{
    [Table("send_header")]
    public class SendHeader : BaseEntity
    {
        public SendHeader()
        {
            SendHeaderDetailList = new HashSet<SendHeaderDetail>();
        }

        [Column("application_id")]
        public int? ApplicationId { get; set; }
        [Column("sub_application_id")]
        public int? SubApplicationId { get; set; }
        [Column("by_name")]
        public string ByName { get; set; }
        [Column("by_email")]
        public string ByEmail { get; set; }
        [Column("desc_subject")]
        public string DescSubject { get; set; }
        [Column("send_date")]
        public DateTime? SendDate { get; set; }
        [Column("send_user")]
        public string SendUser { get; set; }
        [Column("for_mail")]
        public string ForMail { get; set; }
        [Column("for_mail_cc")]
        public string ForMailCc { get; set; }
        [Column("for_mail_bcc")]
        public string ForMailBcc { get; set; }
        [Column("process_id")]
        public int? ProcessId { get; set; }
        [Column("sub_process_id")]
        public int? SubProcessId { get; set; }
        [Column("template_id")]
        public int? TemplateId { get; set; }
        [Column("sn_complete")]
        public int? SnComplete { get; set; }
        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }
        [Column("sn_in_process")]
        public int? SnInProcess { get; set; }
        [Column("scheduling_date")]
        public DateTime? SchedulingDate { get; set; }
        [Column("sn_massive")]
        public bool? SnMassive { get; set; }
        public virtual ICollection<SendHeaderDetail> SendHeaderDetailList { get; set; }
    }
}
