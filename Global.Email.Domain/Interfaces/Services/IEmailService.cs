using Mandrill.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task<List<EmailResult>> Send(Entities.Email emailRequest);
        Task Add(Entities.Email email);
        IEnumerable<Entities.Email> GetAll();
    }
}
