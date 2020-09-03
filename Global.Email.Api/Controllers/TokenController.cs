using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Global.Email.Application.RequestModel;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Global.Email.Api.Controllers
{
    public class TokenController : BaseController
    {
        private readonly IConfiguration _configuration;
        protected readonly INetCoreUserService<NetCoreUser> _userService;
        protected readonly IPasswordService _passwordService;

        public TokenController(IConfiguration configuration, IPasswordService passwordService, INetCoreUserService<NetCoreUser> userService, IMapper mapper, ILogger<BaseController> logger)
        : base(mapper, logger)
        {
            _configuration = configuration;
            _passwordService = passwordService;
            _userService = userService;
        }

        /// <summary>
        /// Generate token for consuming api
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Authentication([FromBody] NetCoreUserRequest userLogin)
        {
            try
            {
                var result = await GetUser(userLogin);

                if (!result.Item1)
                    return BadRequest();

                var token = GenerateToken(result.Item2);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private async Task<(bool, NetCoreUser)> GetUser(NetCoreUserRequest request)
        {
            try
            {
                var entity = _mapper.Map<NetCoreUser>(request);
                var response = await _userService.GetByUser(entity);

                if (!response.Item1)
                    return (false, null);

                var isValid = _passwordService.Check(response.Item2.Password, request.Password);

                return (isValid, response.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al crear una transacción. Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private string GenerateToken(NetCoreUser user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("User", user.User),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            int.TryParse(_configuration["Authentication:ExpireTime"], out int expire);

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(expire)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}