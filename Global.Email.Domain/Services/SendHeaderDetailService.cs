using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global.Email.Domain.Services
{
    public class SendHeaderDetailService : ISendHeaderDetailService<SendHeaderDetail>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendHeaderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Add(SendHeaderDetail entity)
        {
            var sendHeader = await _unitOfWork.GetRepository<SendHeader>().GetById(entity.SendHeaderId.GetValueOrDefault());

            if (sendHeader == null)
                return 400;

            await _unitOfWork.GetRepository<SendHeaderDetail>().Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            if(result > 0)
                return 201;
            else
                return 400;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.GetRepository<SendHeaderDetail>().Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<SendHeaderDetail> GetAll()
        {
            var list = _unitOfWork.GetRepository<SendHeaderDetail>().GetAll();
            return list;
        }

        public async Task<SendHeaderDetail> GetById(int id)
        {
            var entity = await _unitOfWork.GetRepository<SendHeaderDetail>().GetById(id);
            return entity;
        }

        public async Task<int> Update(SendHeaderDetail entity)
        {
            _unitOfWork.GetRepository<SendHeaderDetail>().Update(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
