using System;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.Interface;
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
    public class SendHeaderDetailController : BaseController
    {
        protected readonly ISendHeaderDetailService<SendHeaderDetail> _sendHeaderDetailService;

        public SendHeaderDetailController(ISendHeaderDetailService<SendHeaderDetail> sendHeaderDetailService, IMapper mapper, ILogger<BaseController> logger)
        : base(mapper, logger)
        {
            _sendHeaderDetailService = sendHeaderDetailService;
        }

        /// <summary>
        /// Get All SendHeaderDetail items.
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IGlobalResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SendHeaderDetailRequest emailRequest)
        {
            try
            {   
                var email = _mapper.Map<SendHeaderDetail>(emailRequest);
                var result = await _sendHeaderDetailService.Add(email);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}   