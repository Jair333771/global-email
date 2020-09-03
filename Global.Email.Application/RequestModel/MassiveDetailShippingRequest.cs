using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Global.Email.Application.RequestModel
{
    public class MassiveDetailShippingRequest
	{		
		public int Id { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El consecutivo es requerido.")]
		public Guid Consecutive { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El número de lista es requerido.")]
		public int ListNumber { get; set; }
		
        [NotNull()]
		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
        [Required(ErrorMessage = "El correo es requerido.")]
		public string Email { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El proceso id es requerido.")]
		public int? ProcessId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El subproceso id es requerido.")]
		public int? SubProcessId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "La plantilla id es requerida.")]
		public int? TemplateId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El id de lista es requerido.")]
		public int? ListId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El id de campaña es requerido.")]
		public int? CampaignId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El pv cero code es requerido.")]
		public int? PvCeroId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El id de persona es requerido.")]
		public decimal? PersonId { get; set; }
		
		public string Column1 { get; set; }
		
		public string Column2 { get; set; }
		
		public string Column3 { get; set; }
		
		public string Column4 { get; set; }
		
		public string Column5 { get; set; }
		
		public string Column6 { get; set; }
		
		public string Column7 { get; set; }
		
		public string Column8 { get; set; }
		
		public string Column9 { get; set; }
		
		public string Column10 { get; set; }
		
		public string Column11 { get; set; }
		
		public string Column12 { get; set; }
		
		public string Column13 { get; set; }
		
		public string Column14 { get; set; }
		
		public string Column15 { get; set; }
		
		public string Column16 { get; set; }
		
		public string Column17 { get; set; }
		
		public string Column18 { get; set; }
		
		public string Column19 { get; set; }
		
		public string Column20 { get; set; }
		
		public string Status { get; set; }
		
		public DateTime? StatusDate { get; set; }
		
		public bool? SnComplete { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El id api member es requerido.")]
		public string MemberApiId { get; set; }
		
        [NotNull]
		[Required(ErrorMessage = "El id email api es requerido.")]
		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
		public string EmailApiId { get; set; }
		
		public string DescError { get; set; }
	}
}
