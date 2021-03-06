﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.RequestModel;
using Global.Email.Application.ResponseModel;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DataContract]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        protected readonly IEmailService _emailService;
        protected readonly IMapper _mapper;

        public EmailController(IEmailService emailService, IMapper mapper, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<EmailResponse>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var response = _emailService.GetAll();
                var emailResponse = _mapper.Map<List<EmailResponse>>(response);
                return Ok(emailResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
