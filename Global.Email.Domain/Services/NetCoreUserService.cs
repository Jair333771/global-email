﻿using AutoMapper;
using Global.Email.Application.DTOs;
using Global.Email.Application.Enumerations;
using Global.Email.Application.Interface;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global.Email.Domain.Services
{
    public class NetCoreUserService : BaseService ,INetCoreUserService<NetCoreUser>
    {
        private readonly IUserRepository _userRepo;

        public NetCoreUserService(IUserRepository userRepo, IUnitOfWork unitOfWork, IGlobalResponse globalResponse, IErrorResponses errorResponse, IMapper mapper)
        : base(unitOfWork, globalResponse, errorResponse, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<IGlobalResponse> Add(NetCoreUser entity)
        {
            await _unitOfWork.GetRepository<NetCoreUser>().Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                var model = _mapper.Map<NetCoreUserDto>(entity);
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
            await _unitOfWork.GetRepository<NetCoreUser>().Delete(id);
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
            var result = _unitOfWork.GetRepository<NetCoreUser>().GetAll();

            if (result.Count() > 0)
            {
                var model = _mapper.Map<IEnumerable<NetCoreUserDto>>(result);
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
            var result = await _unitOfWork.GetRepository<NetCoreUser>().GetById(id);

            if (result != null)
            {
                var model = _mapper.Map<NetCoreUserDto>(result);
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

        public async Task<(bool, NetCoreUser)> GetByUser(NetCoreUser entity)
        {
            var result = await _userRepo.GetByUser(entity.User);
            return (result != null, result);
        }

        public async Task<IGlobalResponse> Update(NetCoreUser entity)
        {
            _unitOfWork.GetRepository<NetCoreUser>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                var model = _mapper.Map<NetCoreUserDto>(result);
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