using AutoMapper;
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
            SetGlobalResponse<NetCoreUser, NetCoreUserDto>(result, entity, CustomErrorType.Created, 201, 400);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> Delete(int id)
        {
            await _unitOfWork.GetRepository<NetCoreUser>().Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<string, string>(result, "Registro eliminado exitosamente.", CustomErrorType.Deleted);
            return _globalResponse;
        }

        public IGlobalResponse GetAll()
        {
            var result = _unitOfWork.GetRepository<NetCoreUser>().GetAll();
            SetGlobalResponse<IEnumerable<NetCoreUser>, IEnumerable<NetCoreUserDto>>(result.Count(), result, CustomErrorType.NoContent, 200, 204);
            return _globalResponse;
        }

        public async Task<IGlobalResponse> GetById(int id)
        {
            var result = await _unitOfWork.GetRepository<NetCoreUser>().GetById(id);
            SetGlobalResponse<NetCoreUser, NetCoreUserDto>(1, result, CustomErrorType.NotFound);
            return _globalResponse;
        }

        public async Task<(bool, NetCoreUser)> GetByUser(NetCoreUser entity)
        {
            var result = await _userRepo.GetByUser(entity.User);
            SetGlobalResponse<NetCoreUser, NetCoreUserDto>(1, result, CustomErrorType.NotFound);
            return (result != null, result);
        }

        public async Task<IGlobalResponse> Update(NetCoreUser entity)
        {
            _unitOfWork.GetRepository<NetCoreUser>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            SetGlobalResponse<NetCoreUser, NetCoreUserDto>(result, entity, CustomErrorType.Updated);
            return _globalResponse;
        }
    }
}