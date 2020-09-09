using Global.Email.Application.Enumerations;
using Global.Email.Application.Interface;
using System.Collections.Generic;

namespace Global.Email.Application.ResponseModel
{
    public class ErrorListResponse : IErrorResponses
    {
        public List<ErrorResponse> Errors { get; set; } = new List<ErrorResponse>
        {
            new ErrorResponse
            {
                Type = CustomErrorType.Created,
                Message = "El registro no ha sido agregado, por favor verifica la información"
            },
            new ErrorResponse
            {
                Type = CustomErrorType.Deleted,
                Message = "El registro no ha sido eliminado, por favor verifica la información"
            },
            new ErrorResponse
            {
                Type = CustomErrorType.NoContent,
                Message = "La consulta no arrojo ningun resultado."
            },
            new ErrorResponse
            {
                Type = CustomErrorType.Updated,
                Message = "La solicitud ha sido rechazada, por favor inténtalo nuevamente."
            },
            new ErrorResponse
            {
                Type = CustomErrorType.NotFound,
                Message = "El sistema no pudo encontrar el contenido solicitado, por favor verifica la información."
            },
            new ErrorResponse
            {
                Type = CustomErrorType.Server,
                Message = "Ha ocurrido un error inesperado, por favor inténtalo nuevamente."
            },
            new ErrorResponse
            {
                Type = CustomErrorType.BadRequest,
                Message = "No hemos podido procesar tu solicitud, por favor inténtalo nuevamente."
            }
        };
    }
}