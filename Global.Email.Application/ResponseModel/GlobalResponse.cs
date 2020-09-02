using Global.Email.Application.Interface;

namespace Global.Email.Application.ResponseModel
{
    public class GlobalResponse : IGlobalResponse
    {
        public object Data { get; set; }
        public int Status { get; set; }
    }
}
