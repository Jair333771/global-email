using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;

namespace Global.Email.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [DataContract]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper, ILogger<BaseController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
