using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Global.Email.Domain.Services
{
    public class SendHeaderService : ISendHeaderService<SendHeader>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendHeaderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(SendHeader entity)
        {
            await _unitOfWork.GetRepository<SendHeader>().Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return 201;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.GetRepository<SendHeader>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<SendHeader> GetAll()
        {
            var list = _unitOfWork.GetRepository<SendHeader>().GetAll();
            return list;
        }

        public async Task<SendHeader> GetById(int id)
        {
            try
            {
                var entity = await _unitOfWork.GetRepository<SendHeader>().GetById(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Update(SendHeader entity)
        {
            _unitOfWork.GetRepository<SendHeader>().Update(entity);
            _unitOfWork.SaveChangesAsync();
            return 304;
        }
    }
}
