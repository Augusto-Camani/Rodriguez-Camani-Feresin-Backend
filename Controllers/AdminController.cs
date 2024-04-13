using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.Models;

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

    [HttpGet]
    public IActionResult GetUsers(){
        return Ok(_adminService.GetUsers());
    }
}
