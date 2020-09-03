using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using Mandrill;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global.Email.Domain.Services
{
    public class EmailService : IEmailService
    {
        private IMandrillApi _api;
        private readonly IUnitOfWork _unitOfWork;

        private SendMessageRequest _sendMessageRequest;
        private EmailAddress _emailAddress;
        private EmailMessage _emailMessage;
        private List<EmailAddress> _listEmailAdress;

        public EmailService(IMandrillApi api, IUnitOfWork unitOfWork, List<EmailAddress> listEmailAdress,
            SendMessageRequest sendMessageRequest, EmailAddress emailAddress, EmailMessage emailMessage)
        {
            _api = api;
            _unitOfWork = unitOfWork;
            _sendMessageRequest = sendMessageRequest;
            _emailAddress = emailAddress;
            _emailMessage = emailMessage;
            _listEmailAdress = listEmailAdress;
        }

        public async Task<List<EmailResult>> Send(Entities.Email email)
        {
            try
            {
                _emailAddress.Email = email.ToEmail;
                _emailAddress.Name = "User Name";
                _emailAddress.Type = "to";

                _listEmailAdress.Clear();
                _listEmailAdress.Add(_emailAddress);

                _emailMessage.To = _listEmailAdress;
                _emailMessage.Text = email.DescMessage;

                _sendMessageRequest.Message = _emailMessage;

                var emailResult = await _api.SendMessage(_sendMessageRequest);

                var result = await ValidateStatus(emailResult, email);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmailResult>> ValidateStatus(List<EmailResult> emailResult, Entities.Email email)
        {
            try
            {
                foreach (var item in emailResult)
                {
                    email.Status = item.Status.ToString();
                    await Add(email);
                }
                return emailResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Add(Entities.Email email)
        {
            try
            {
                await _unitOfWork.GetRepository<Entities.Email>().Add(email);
                var result = await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Entities.Email> GetAll()
        {
            try
            {
                var list = _unitOfWork.GetRepository<Entities.Email>().GetAll();
                return list;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message);
            }
        }
    }
}