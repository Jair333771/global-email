using AutoMapper;
using Global.Email.Application.DTOs;
using Global.Email.Application.Enumerations;
using Global.Email.Application.Interface;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global.Email.Domain.Services
{
    public class MassiveDetailShippingService : BaseService, IBaseService<MassiveDetailShipping>
    {
        public MassiveDetailShippingService(IUnitOfWork unitOfWork, IGlobalResponse globalResponse, IErrorResponses errorResponse, IMapper mapper)
        : base(unitOfWork, globalResponse, errorResponse, mapper)
        { }
        
        public async Task<IGlobalResponse> Add(MassiveDetailShipping entity)
        {
            await _unitOfWork.GetRepository<MassiveDetailShipping>().Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<MassiveDetailShipping, MassiveDetailShippingDto>(result, entity, CustomErrorType.Created, 201, 400);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> Delete(int id)
        {
            await _unitOfWork.GetRepository<MassiveDetailShipping>().Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<string, string>(result, "Registro eliminado exitosamente.", CustomErrorType.Deleted);
            return _globalResponse;
        }

        public IGlobalResponse GetAll()
        {
            var result = _unitOfWork.GetRepository<MassiveDetailShipping>().GetAll();
            SetGlobalResponse<IEnumerable<MassiveDetailShipping>, IEnumerable<MassiveDetailShippingDto>>(result.Count(), result, CustomErrorType.NoContent, 200, 204);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> GetById(int id)
        {
            var result = await _unitOfWork.GetRepository<MassiveDetailShipping>().GetById(id);
            SetGlobalResponse<MassiveDetailShipping, MassiveDetailShippingDto>(1, result, CustomErrorType.NotFound);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> Update(MassiveDetailShipping entity)
        {
            _unitOfWork.GetRepository<MassiveDetailShipping>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<MassiveDetailShipping, MassiveDetailShippingDto>(result, entity, CustomErrorType.Updated);
            return _globalResponse;
        }
    }
}