using Global.Email.Application.Enumerations;

namespace Global.Email.Application.ResponseModel
{
    public class ErrorResponse
    {
        public CustomErrorType Type { get; set; }
        public string Message { get; set; }
    }
}
