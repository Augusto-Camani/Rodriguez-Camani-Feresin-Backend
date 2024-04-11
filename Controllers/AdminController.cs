using Microsoft.AspNetCore.Mvc;

namespace Rodriguez_Camani_Feresin_Backend;

[Route("api/[controller]")]
[ApiController]
public class AdminController:ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
        
    }

    [HttpGet("getAdmins")]
    public IActionResult GetAdmins(){
        return Ok(_adminService.GetAll());
    }

}
