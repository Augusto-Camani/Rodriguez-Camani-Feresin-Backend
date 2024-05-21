using Microsoft.AspNetCore.Mvc;

namespace Rodriguez_Camani_Feresin_Backend;

[Route("/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public UserController()
    {

    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_adminService.GetUsers());
    }
}
