using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global.Email.Domain.Entities
{
    public class MassiveDetailShipping : BaseEntity
	{
		[Column("consecutive")]
		public Guid Consecutive { get; set; }
		[Column("list_number")]
		public int ListNumber { get; set; }
		[Column("email")]
		public string Email { get; set; }
		[Column("process_id")]
		public int? ProcessId { get; set; }
		[Column("sub_process_id")]
		public int? SubProcessId { get; set; }
		[Column("template_id")]
		public int? TemplateId { get; set; }
		[Column("list_id")]
		public int? ListId { get; set; }
		[Column("campaign_id")]
		public int? CampaignId { get; set; }
		[Column("pv_cero_id")]
		public int? PvCeroId { get; set; }
		[Column("person_id")]
		public decimal? PersonId { get; set; }
		[Column("column1")]
		public string Column1 { get; set; }
		[Column("column2")]
		public string Column2 { get; set; }
		[Column("column3")]
		public string Column3 { get; set; }
		[Column("column4")]
		public string Column4 { get; set; }
		[Column("column5")]
		public string Column5 { get; set; }
		[Column("column6")]
		public string Column6 { get; set; }
		[Column("column7")]
		public string Column7 { get; set; }
		[Column("column8")]
		public string Column8 { get; set; }
		[Column("column9")]
		public string Column9 { get; set; }
		[Column("column10")]
		public string Column10 { get; set; }
		[Column("column11")]
		public string Column11 { get; set; }
		[Column("column12")]
		public string Column12 { get; set; }
		[Column("column13")]
		public string Column13 { get; set; }
		[Column("column14")]
		public string Column14 { get; set; }
		[Column("column15")]
		public string Column15 { get; set; }
		[Column("column16")]
		public string Column16 { get; set; }
		[Column("column17")]
		public string Column17 { get; set; }
		[Column("column18")]
		public string Column18 { get; set; }
		[Column("column19")]
		public string Column19 { get; set; }
		[Column("column20")]
		public string Column20 { get; set; }
		[Column("status")]
		public string Status { get; set; }
		[Column("status_date")]
		public DateTime? StatusDate { get; set; }
		[Column("sn_complete")]
		public bool? SnComplete { get; set; }
		[Column("member_api_id")]
		public string MemberApiId { get; set; }
		[Column("email_api_id")]
		public string EmailApiId { get; set; }
		[Column("desc_error")]
		public string DescError { get; set; }
	}
}
