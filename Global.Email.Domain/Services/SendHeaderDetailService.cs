﻿using AutoMapper;
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
    public class SendHeaderDetailService : BaseService, ISendHeaderDetailService<SendHeaderDetail>
    {
        public SendHeaderDetailService(IUnitOfWork unitOfWork, IGlobalResponse globalResponse, IErrorResponses errorResponse, IMapper mapper)
               : base(unitOfWork, globalResponse, errorResponse, mapper)
        { }

        public async Task<IGlobalResponse> Add(SendHeaderDetail entity)
        {
            var sendHeader = await _unitOfWork.GetRepository<SendHeader>().GetById(entity.SendHeaderId.GetValueOrDefault());

            if (sendHeader == null)
            {
                _globalResponse.Status = 400;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.NotFound).FirstOrDefault();
                return _globalResponse;
            }

            await _unitOfWork.GetRepository<SendHeaderDetail>().Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                var model = _mapper.Map<SendHeaderDetailDto>(entity);
                _globalResponse.Status = 201;
                _globalResponse.Data = model;
            }
            else
            {
                _globalResponse.Status = 400;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.Created).FirstOrDefault();
            }

            return _globalResponse;
        }

        public async Task<IGlobalResponse> Delete(int id)
        {
            await _unitOfWork.GetRepository<SendHeaderDetail>().Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                _globalResponse.Status = 200;
                _globalResponse.Data = "Registro eliminado exitosamente.";
            }
            else
            {
                _globalResponse.Status = 404;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.Deleted).FirstOrDefault();
            }

            return _globalResponse;
        }

        public IGlobalResponse GetAll()
        {
            var result = _unitOfWork.GetRepository<SendHeaderDetail>().GetAll();

            if (result.Count() > 0)
            {
                var model = _mapper.Map<IEnumerable<SendHeaderDetailDto>>(result);
                _globalResponse.Status = 201;
                _globalResponse.Data = model;
            }
            else
            {
                _globalResponse.Status = 204;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.NoContent).FirstOrDefault();
            }

            return _globalResponse;
        }

        public async Task<IGlobalResponse> GetById(int id)
        {
            var result = await _unitOfWork.GetRepository<SendHeaderDetail>().GetById(id);

            if (result != null)
            {
                var model = _mapper.Map<SendHeaderDetailDto>(result);
                _globalResponse.Status = 200;
                _globalResponse.Data = model;
            }
            else
            {
                _globalResponse.Status = 204;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.NoContent).FirstOrDefault();
            }

            return _globalResponse;
        }

        public async Task<IGlobalResponse> Update(SendHeaderDetail entity)
        {
            _unitOfWork.GetRepository<SendHeaderDetail>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                var model = _mapper.Map<SendHeaderDetailDto>(result);
                _globalResponse.Status = 200;
                _globalResponse.Data = model;
            }
            else
            {
                _globalResponse.Status = 400;
                _globalResponse.Error = _errorResponse.Errors.Where(x => x.Type == CustomErrorType.Updated).FirstOrDefault();
            }

            return _globalResponse;
        }
    }
}