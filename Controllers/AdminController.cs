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

    [HttpGet("getUsers")]
    public IActionResult GetUsers(){
        return Ok(_adminService.GetUsers());
    }

    [HttpGet("getAdmins")]
    public IActionResult GetAdmins(){
        return Ok(_adminService.GetAdmins());
    }

    [HttpGet("getBarbers")]
    public IActionResult GetBarbers(){
        return Ok(_adminService.GetBarbers());
    }

    [HttpGet("getClients")]
    public IActionResult GetClient(){
        return Ok(_adminService.GetClients());
    }
    
    [HttpGet("getUserById{id}")]
    public IActionResult GetUserById(int id){
        return Ok(_adminService.GetUserById(id));
    }

}
