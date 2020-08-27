using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.RequestModel;
using Global.Email.Application.ResponseModel;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global.Email.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DataContract]
    public class EmailController : ControllerBase
    {
        protected readonly IEmailService _emailService;
        protected readonly IMapper _mapper;

        public EmailController(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _emailService.GetAll();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailRequest emailRequest)
        {
            try
            {
                var email = _mapper.Map<Domain.Entities.Email>(emailRequest);
                var response = await _emailService.Send(email);
                var emailResponse = _mapper.Map<List<EmailResponse>>(response);
                return Ok(emailResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
