using Global.Email.Application.ResponseModel;
using System.Collections.Generic;

namespace Global.Email.Application.Interface
{
    public interface IGlobalResponse
    {
        object Data { get; set; }
        List<ErrorResponse> Errors { get; set; }
        int Status { get; set; }
    }
}
