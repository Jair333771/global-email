using AutoMapper;
using Global.Email.Application.Enumerations;
using Global.Email.Application.Interface;
using Global.Email.Domain.Interfaces.UnitOfWork;
using System.Linq;

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

        protected void SetGlobalResponse<TEntity, TDto>(int result, TEntity entity, CustomErrorType type, int statusOk = 200, int statusFail = 404)
        {
            _globalResponse.Data = new object();

            if (result > 0 && entity != null)
            {
                var model = _mapper.Map<TDto>(entity);
                _globalResponse.Status = statusOk;
                _globalResponse.Data = model;
                _globalResponse.Error = null;
            }
            else
            {
                _globalResponse.Data = null;
                _globalResponse.Status = statusFail;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == type).FirstOrDefault();
            }
        }
    }
}