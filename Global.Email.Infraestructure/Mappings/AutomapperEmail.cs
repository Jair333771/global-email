using AutoMapper;
using Global.Email.Application.DTOs;
using Global.Email.Application.RequestModel;
using Global.Email.Application.ResponseModel;
using Global.Email.Domain.Entities;
using Mandrill.Models;

namespace Global.Email.Infraestructure.Mappings
{
    class AutomapperEmail : Profile
    {
        public AutomapperEmail()
        {
            NetCoreUser();
            Email();
            SendHeader();
            SendHeaderDetail();
            MassiveDetailShipping();
        }

        public void NetCoreUser()
        {
            CreateMap<NetCoreUserRequest, NetCoreUser>();
            CreateMap<NetCoreUser, NetCoreUserRequest>();

            CreateMap<NetCoreUserDto, NetCoreUser>();
            CreateMap<NetCoreUser, NetCoreUserDto>();
        }
        public void Email() 
        {
            CreateMap<EmailRequest, Domain.Entities.Email>();
            CreateMap<Domain.Entities.Email, EmailRequest>();

            CreateMap<EmailResponse, Domain.Entities.Email>();
            CreateMap<Domain.Entities.Email, EmailResponse>();

            CreateMap<EmailResponse, EmailResult>();
            CreateMap<EmailResult, EmailResponse>();

            CreateMap<EmailDto, Domain.Entities.Email>();
            CreateMap<Domain.Entities.Email, EmailDto>();
        }
        public void SendHeader()
        {
            CreateMap<SendHeader, SendHeaderDto>();
            CreateMap<SendHeaderDto, SendHeader>();

            CreateMap<SendHeader, SendHeaderRequest>();
            CreateMap<SendHeaderRequest, SendHeader>();

            CreateMap<SendHeaderRequest, SendHeaderResponse>();
            CreateMap<SendHeaderResponse, SendHeaderRequest>();
        }
        public void SendHeaderDetail()
        {
            CreateMap<SendHeaderDetail, SendHeaderDetailRequest>();
            CreateMap<SendHeaderDetailRequest, SendHeaderDetail>();

            CreateMap<SendHeaderDetail, SendHeaderDetailDto>();
            CreateMap<SendHeaderDetailDto, SendHeaderDetail>();

            CreateMap<SendHeaderDetail, SendHeaderDetailResponse>();
            CreateMap<SendHeaderDetailResponse, SendHeaderDetail>();

            CreateMap<SendHeaderDetailRequest, SendHeaderDetailResponse>();
            CreateMap<SendHeaderDetailResponse, SendHeaderDetailRequest>();
        }
        public void MassiveDetailShipping()
        {
            CreateMap<MassiveDetailShipping, MassiveDetailShippingDto>();
            CreateMap<MassiveDetailShippingDto, MassiveDetailShipping>();

            CreateMap<MassiveDetailShipping, MassiveDetailShippingRequest>();
            CreateMap<MassiveDetailShippingRequest, MassiveDetailShipping>();

            CreateMap<MassiveDetailShipping, MassiveDetailShippingResponse>();
            CreateMap<MassiveDetailShippingResponse, MassiveDetailShipping>();
        }
    }
}