using System;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.RequestModel;
using Global.Email.Application.ResponseModel;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [DataContract]
    public class SendHeaderDetailController : ControllerBase
    {
        private readonly ILogger<SendHeaderController> _logger;
        protected readonly ISendHeaderDetailService<SendHeaderDetail> _sendHeaderDetailService;
        protected readonly IMapper _mapper;

        public SendHeaderDetailController(ISendHeaderDetailService<SendHeaderDetail> sendHeaderDetailService, IMapper mapper, ILogger<SendHeaderController> logger)
        {
            _sendHeaderDetailService = sendHeaderDetailService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get All SendHeaderDetail items.
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(SendHeaderDetailResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SendHeaderDetailRequest emailRequest)
        {
            try
            {   
                var email = _mapper.Map<SendHeaderDetail>(emailRequest);
                var result = await _sendHeaderDetailService.Add(email);
                var emailResponse = _mapper.Map<SendHeaderDetailResponse>(emailRequest);
                return StatusCode(result, emailResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}   