using System;

namespace Global.Email.Application.DTOs
{
    public class SendHeaderDetailDto
    {
        public int? SendHeaderId { get; set; }
        public string ApiId { get; set; }
        public string FromEmail { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? StatusCode { get; set; }
        public string DescState { get; set; }
        public string DetailState { get; set; }
        public int? DestinationTypeId { get; set; }
        public long? PersonId { get; set; }
        public int? PvCeroId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? DetailId { get; set; }
        public int? SnInProcess { get; set; }
        public int? PqCode { get; set; }
        public int? AvanceCode { get; set; }
        public int? NumberOperations { get; set; }
    }
}