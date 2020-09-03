using Global.Email.Application.ResponseModel;
using System.Collections.Generic;

namespace Global.Email.Application.Interface
{
    public interface IErrorResponses
    {
        List<ErrorResponse> Errors { get; set; }
    }
}
