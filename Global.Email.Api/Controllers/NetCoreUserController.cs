using System;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.DTOs;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Enumerations;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class NetCoreUserController : ControllerBase
    {
        private readonly ILogger<SendHeaderController> _logger;
        private readonly IUserService<NetCoreUser> _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public NetCoreUserController(IUserService<NetCoreUser> userService, IMapper mapper, IPasswordService passwordService, ILogger<SendHeaderController> logger)
        {
            _passwordService = passwordService;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(NetCoreUserDto request)
        {
            try
            {
                var user = _mapper.Map<NetCoreUser>(request);

                user.Password = _passwordService.Hash(user.Password);
                var result = await _userService.Add(user);

                request = _mapper.Map<NetCoreUserDto>(user);
                return Ok(request);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
