using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        [HttpPost("/pay")]
        public IActionResult Pay()
        {
            return Ok();
        }
    }
}