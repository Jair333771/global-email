using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.DTOs;
using Global.Email.Application.Enumerations;
using Global.Email.Application.Interface;
using Global.Email.Application.RequestModel;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    public class NetCoreUserController : BaseController
    {
        private readonly INetCoreUserService<NetCoreUser> _userService;
        private readonly IPasswordService _passwordService;

        public NetCoreUserController(INetCoreUserService<NetCoreUser> userService, IMapper mapper, IPasswordService passwordService, ILogger<BaseController> logger)
            :base(mapper, logger)
        {
            _passwordService = passwordService;
            _userService = userService;
        }

        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(IGlobalResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add([FromBody] NetCoreUserRequest request)
        {
            try
            {
                var user = _mapper.Map<NetCoreUser>(request);
                user.Password = _passwordService.Hash(user.Password);
                var result = await _userService.Add(user);
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