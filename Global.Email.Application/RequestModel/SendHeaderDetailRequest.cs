using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Global.Email.Application.RequestModel
{
    public class SendHeaderDetailRequest
    {
        public int Id { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El SendHeaderId es requerido.", AllowEmptyStrings = false)]
        public int? SendHeaderId { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El ApiId es requerido.", AllowEmptyStrings = false)]
        public string ApiId { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El remitente es requerido.", AllowEmptyStrings = false)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
        public string FromEmail { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? StatusCode { get; set; }

        public string DescState { get; set; }

        public string DetailState { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El id tipo destino es requerido.", AllowEmptyStrings = false)]
        public int? DestinationTypeId { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El id de persona es requerido.", AllowEmptyStrings = false)]
        public long? PersonId { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El id pv cero es requerido.", AllowEmptyStrings = false)]
        public int? PvCeroId { get; set; }

        public DateTime? Creation_date => DateTime.Now;

        [NotNull()]
        [Required(ErrorMessage = "El id de detalle es requerido.", AllowEmptyStrings = false)]
        public int? DetailId { get; set; }

        public int? SnInProcess { get; set; }

        [NotNull()]
        [Required(ErrorMessage = "El código pq es requerido.", AllowEmptyStrings = false)]
        public int? PqCode { get; set; }

        public int? AvanceCode { get; set; }

        public int? NumberOperations { get; set; }
    }
}