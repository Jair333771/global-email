using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Global.Email.Application.RequestModel
{
    public class SendHeaderRequest
    {
        public int Id { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El id de aplicación es requerido.")]
        public int? ApplicationId { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El id de sub aplicación es requerido.", AllowEmptyStrings = false)]
        public int? SubApplicationId { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string ByName { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El correo es requerido.", AllowEmptyStrings = false)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
        public string ByEmail { get; set; }

        [NotNull]
        [Required(ErrorMessage = "La descripción del asunto es requerido.", AllowEmptyStrings = false)]
        public string DescSubject { get; set; }

        public DateTime? SendDate { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El usuario que envía es requerido.", AllowEmptyStrings = false)]
        public string SendUser { get; set; }

        [NotNull]
        [Required(ErrorMessage = "La correo de destino es requerido.", AllowEmptyStrings = false)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
        public string ForMail { get; set; }

        [AllowNull]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
        public string ForMailCc { get; set; }

        [AllowNull]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "el formato de correo es inválido")]
        public string ForMailBcc { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El proceso es requerido.", AllowEmptyStrings = false)]
        public int? ProcessId { get; set; }
        [NotNull]
        [Required(ErrorMessage = "El subproceso es requerido.", AllowEmptyStrings = false)]
        public int? SubProcessId { get; set; }

        [NotNull]
        [Required(ErrorMessage = "La plantilla es requerido.", AllowEmptyStrings = false)]
        public int? TemplateId { get; set; }

        public int? SnComplete { get; set; }

        public DateTime? CreationDate => DateTime.Now;

        public int? SnInProcess { get; set; }

        public DateTime? SchedulingDate { get; set; }

        public bool? SnMassive { get; set; }
    }
}