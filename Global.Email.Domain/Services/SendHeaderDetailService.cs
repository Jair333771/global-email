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
    public class SendHeaderDetailService : BaseService, IBaseService<SendHeaderDetail>
    {
        public SendHeaderDetailService(IUnitOfWork unitOfWork, IGlobalResponse globalResponse, IErrorResponses errorResponse, IMapper mapper)
               : base(unitOfWork, globalResponse, errorResponse, mapper)
        { }

        public async Task<IGlobalResponse> Add(SendHeaderDetail entity)
        {
            if(!(await ValidateHeader(entity.SendHeaderId.GetValueOrDefault())))
                return _globalResponse;

            await _unitOfWork.GetRepository<SendHeaderDetail>().Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<SendHeaderDetail, SendHeaderDetailDto>(result, entity, CustomErrorType.Created, 201, 400);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> Delete(int id)
        {
            await _unitOfWork.GetRepository<SendHeaderDetail>().Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<string, string>(result, "Registro eliminado exitosamente.", CustomErrorType.Deleted);
            return _globalResponse;
        }

        public IGlobalResponse GetAll()
        {
            var result = _unitOfWork.GetRepository<SendHeaderDetail>().GetAll();
            SetGlobalResponse<IEnumerable<SendHeaderDetail>, IEnumerable<SendHeaderDetailDto>>(result.Count(), result, CustomErrorType.NoContent, 200, 204);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> GetById(int id)
        {
            var result = await _unitOfWork.GetRepository<SendHeaderDetail>().GetById(id);
            SetGlobalResponse<SendHeaderDetail, SendHeaderDetailDto>(1, result, CustomErrorType.NotFound);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> Update(SendHeaderDetail entity)
        {
            _unitOfWork.GetRepository<SendHeaderDetail>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<SendHeaderDetail, SendHeaderDetailDto>(result, entity, CustomErrorType.Updated);
            return _globalResponse;
        }

        #region Validations
        public async Task<bool> ValidateHeader(int id)
        {
            var sendHeader = await _unitOfWork.GetRepository<SendHeader>().GetById(id);

            if (sendHeader == null)
            {
                _globalResponse.Status = 400;
                _globalResponse.Data = "El sendHeaderId enviado ha sido eliminado o no existe.";
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.NotFound).FirstOrDefault();
                return false;
            }
            return true;
        }
        #endregion
    }
}