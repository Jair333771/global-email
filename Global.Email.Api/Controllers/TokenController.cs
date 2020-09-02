using System;
using System.IdentityModel.Tokens.Jwt;
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
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IConfiguration _configuration;
        protected readonly IUserService<NetCoreUser> _userService;
        protected readonly IPasswordService _passwordService;
        protected readonly IMapper _mapper;

        public TokenController(IConfiguration configuration, IPasswordService passwordService, IUserService<NetCoreUser> userService, IMapper mapper, ILogger<TokenController> logger)
        {
            _configuration = configuration;
            _passwordService = passwordService;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] UserLoginRequest userLogin)
        {
            try
            {
                var result = await CheckDataUser(userLogin);

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

        private async Task<(bool, NetCoreUser)> CheckDataUser(UserLoginRequest request)
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
