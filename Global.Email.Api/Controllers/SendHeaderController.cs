using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.DTOs;
using Global.Email.Application.RequestModel;
using Global.Email.Application.ResponseModel;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [DataContract]
    public class SendHeaderController : ControllerBase
    {
        private readonly ILogger<SendHeaderController> _logger;
        protected readonly ISendHeaderService<SendHeader> _sendHeaderService;
        protected readonly IMapper _mapper;

        public SendHeaderController(ISendHeaderService<SendHeader> sendHeaderService, IMapper mapper, ILogger<SendHeaderController> logger)
        {
            _sendHeaderService = sendHeaderService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get All SendHeader items.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<SendHeaderDto>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var response = _sendHeaderService.GetAll();
                var emailResponse = _mapper.Map<IEnumerable<SendHeaderDto>>(response);
                return Ok(emailResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Save sendHeader on DB
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(SendHeaderResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SendHeaderRequest emailRequest)
        {
            try
            {
                var email = _mapper.Map<SendHeader>(emailRequest);
                await _sendHeaderService.Add(email);
                var emailResponse = _mapper.Map<SendHeaderResponse>(emailRequest);
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