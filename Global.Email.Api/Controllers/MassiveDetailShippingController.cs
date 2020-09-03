using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.Interface;
using Global.Email.Application.RequestModel;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Authorize]
    public class MassiveDetailShippingController : BaseController
    {
        protected readonly IBaseService<MassiveDetailShipping> _massiveDetailShippingService;

        public MassiveDetailShippingController(IBaseService<MassiveDetailShipping> massiveDetailShippingService, IMapper mapper, ILogger<BaseController> logger)
        : base(mapper, logger)
        {
            _massiveDetailShippingService = massiveDetailShippingService;
        }

        /// <summary>
        /// Save Massive Detail Shipping
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IGlobalResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] MassiveDetailShippingRequest emailRequest)
        {
            try
            {
                var email = _mapper.Map<MassiveDetailShipping>(emailRequest);
                var result = await _massiveDetailShippingService.Add(email);
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