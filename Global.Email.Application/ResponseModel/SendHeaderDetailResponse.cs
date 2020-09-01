namespace Global.Email.Application.ResponseModel
{
    public class SendHeaderDetailResponse
    {
        public string FromEmail { get; set; }
        public long? PersonId { get; set; }
        public int? PvCeroId { get; set; }
        public int? PqCode { get; set; }
    }
}
