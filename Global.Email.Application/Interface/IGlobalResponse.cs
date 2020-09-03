using Global.Email.Application.ResponseModel;
using System.Collections.Generic;

namespace Global.Email.Application.Interface
{
    public interface IGlobalResponse
    {
        object Data { get; set; }
        ErrorResponse Error { get; set; }
        int Status { get; set; }
    }
}
