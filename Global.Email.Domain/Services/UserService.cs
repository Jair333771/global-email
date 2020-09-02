using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Global.Email.Domain.Services
{
    public class UserService : IUserService<NetCoreUser>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepo)
        {
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
        }

        public async Task<int> Add(NetCoreUser entity)
        {
            await _unitOfWork.GetRepository<NetCoreUser>().Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
                return 201;
            else
                return 400;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.GetRepository<NetCoreUser>().Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<NetCoreUser> GetAll()
        {
            return _unitOfWork.GetRepository<NetCoreUser>().GetAll();
        }

        public async Task<NetCoreUser> GetById(int id)
        {
            return await _unitOfWork.GetRepository<NetCoreUser>().GetById(id);
        }

        public async Task<int> Update(NetCoreUser entity)
        {
            _unitOfWork.GetRepository<NetCoreUser>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
                return 200;
            else
                return 304;
        }

        public async Task<(bool, NetCoreUser)> GetByUser(NetCoreUser entity)
        {
            var result = await _userRepo.GetByUser(entity.User);
            var exist = result != null;
            return (exist, result);
        }
    }
}