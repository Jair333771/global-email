namespace Global.Email.Application.ResponseModel
{
    public class SendHeaderResponse
    {
        public int id { get; set; }
        public string ByName { get; set; }
        public string ByEmail { get; set; }
        public int? SnComplete { get; set; }
        public bool? SnMassive { get; set; }
    }
}