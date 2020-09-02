﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.DTOs;
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
    public class SendHeaderController : BaseController
    {
        protected readonly ISendHeaderService<SendHeader> _sendHeaderService;

        public SendHeaderController(ISendHeaderService<SendHeader> sendHeaderService, IMapper mapper, ILogger<BaseController> logger)
        : base(mapper, logger)
        {
            _sendHeaderService = sendHeaderService;
        }

        /// <summary>
        /// Get All SendHeader items.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IGlobalResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var response = _sendHeaderService.GetAll();
                return StatusCode(response.Status, response);
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
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IGlobalResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SendHeaderRequest emailRequest)
        {
            try
            {
                var email = _mapper.Map<SendHeader>(emailRequest);
                var response = await _sendHeaderService.Add(email);
                return StatusCode(response.Status, response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}