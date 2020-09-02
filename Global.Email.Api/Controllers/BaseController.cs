using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Global.Email.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<SendHeaderController> _logger;
    }
}
