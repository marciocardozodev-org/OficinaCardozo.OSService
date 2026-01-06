using Microsoft.AspNetCore.Mvc;

namespace OficinaCardozo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "OK",
            message = "Lambda is working!",
            timestamp = DateTime.UtcNow,
            version = "1.0.0"
        });
    }
}
