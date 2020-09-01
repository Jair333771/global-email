using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global.Email.Domain.Entities
{
    [Table("send_header_detail")]
    public class SendHeaderDetail : BaseEntity
    {
        [Column("Send_header_id")]
        public int? SendHeaderId { get; set; }
        [Column("api_id")]
        public string ApiId { get; set; }
        [Column("from_email")]
        public string FromEmail { get; set; }
        [Column("confirm_date")]
        public DateTime? ConfirmDate { get; set; }
        [Column("return_date")]
        public DateTime? ReturnDate { get; set; }
        [Column("status_code")]
        public int? StatusCode { get; set; }
        [Column("desc_state")]
        public string DescState { get; set; }
        [Column("detail_state")]
        public string DetailState { get; set; }
        [Column("destination_type_id")]
        public int? DestinationTypeId { get; set; }
        [Column("person_id")]
        public long? PersonId { get; set; }
        [Column("pv_cero_id")]
        public int? PvCeroId { get; set; }
        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }
        [Column("detail_id")]
        public int? DetailId { get; set; }
        [Column("sn_in_proceso")]
        public int? SnInProceso { get; set; }
        [Column("pq_code")]
        public int? PqCode { get; set; }
        [Column("avance_code")]
        public int? AvanceCode { get; set; }
        [Column("number_operations")]
        public int? NumberOperations { get; set; }
        [Column("send_header")]
        public virtual SendHeader Sendheader { get; set; }
    }
}
