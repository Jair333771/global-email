using AutoMapper;
using Global.Email.Application.RequestModel;
using Global.Email.Application.ResponseModel;
using Mandrill.Models;

namespace Global.Email.Infraestructure.Mappings
{
    class AutomapperEmail : Profile
    {
        public AutomapperEmail()
        {
            CreateMap<EmailRequest, Domain.Entities.Email>();
            CreateMap<Domain.Entities.Email, EmailRequest>();

            CreateMap<EmailResponse, EmailResult>();
            CreateMap<EmailResult, EmailResponse>();

            CreateMap<EmailResponse, Domain.Entities.Email>();
            CreateMap<Domain.Entities.Email, EmailResponse>();
        }
    }
}