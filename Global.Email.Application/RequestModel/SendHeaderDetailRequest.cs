using System;
using System.ComponentModel.DataAnnotations;

namespace Global.Email.Application.RequestModel
{
    public class SendHeaderDetailRequest
    {
        [Required(ErrorMessage = "El SendHeaderId es requerido.")]
        public int? SendHeaderId { get; set; }
        [Required(ErrorMessage = "El ApiId es requerido.")]
        public string ApiId { get; set; }
        [Required(ErrorMessage = "El remitente es requerido.")]
        public string FromEmail { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? StatusCode { get; set; }
        public string DescState { get; set; }
        public string DetailState { get; set; }
        [Required(ErrorMessage = "El id tipo destino es requerido.")]
        public int? DestinationTypeId { get; set; }
        [Required(ErrorMessage = "El id de persona es requerido.")]
        public long? PersonId { get; set; }
        [Required(ErrorMessage = "El id pv cero es requerido.")]
        public int? PvCeroId { get; set; }
        public DateTime? Creation_date => DateTime.Now;
        [Required(ErrorMessage = "El id de detalle es requerido.")]
        public int? DetailId { get; set; }
        public int? SnInProcess { get; set; }
        [Required(ErrorMessage = "El código pq es requerido.")]
        public int? PqCode { get; set; }
        public int? AvanceCode { get; set; }
        public int? NumberOperations { get; set; }
    }
}
