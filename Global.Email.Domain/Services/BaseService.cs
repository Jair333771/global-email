using AutoMapper;
using Global.Email.Application.Interface;
using Global.Email.Domain.Interfaces.UnitOfWork;

namespace Global.Email.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGlobalResponse _globalResponse;
        protected readonly IErrorResponses _errorResponse;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IGlobalResponse globalResponse, IErrorResponses errorResponse, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _globalResponse = globalResponse;
            _errorResponse = errorResponse;
            _mapper = mapper;
        }
    }
}
