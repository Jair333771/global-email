using System;
using System.ComponentModel.DataAnnotations;

namespace Global.Email.Application.RequestModel
{
    public class SendHeaderRequest
    {
        [Required(ErrorMessage = "El id de aplicación es requerido.")]
        public int? ApplicationId { get; set; }
        [Required(ErrorMessage = "El id de sub aplicación es requerido.")]
        public int? SubApplicationId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string ByName { get; set; }
        [Required(ErrorMessage = "El correo es requerido.")]
        public string ByEmail { get; set; }
        [Required(ErrorMessage = "La descripción del asunto es requerido.")]
        public string DescSubject { get; set; }
        public DateTime? SendDate { get; set; }
        [Required(ErrorMessage = "El usuario que envía es requerido.")]
        public string SendUser { get; set; }
        [Required(ErrorMessage = "La correo de destino es requerido.")]
        public string ForMail { get; set; }
        public string ForMailCc { get; set; }
        public string ForMailBcc { get; set; }
        [Required(ErrorMessage = "El proceso es requerido.")]
        public int? ProcessId { get; set; }
        [Required(ErrorMessage = "El subproceso es requerido.")]
        public int? SubProcessId { get; set; }
        [Required(ErrorMessage = "La plantilla es requerido.")]
        public int? TemplateId { get; set; }
        public int? SnComplete { get; set; }
        public DateTime? CreationDate => DateTime.Now;
        public int? SnInProcess { get; set; }
        public DateTime? SchedulingDate { get; set; }
        public bool? SnMassive { get; set; }
    }
}
