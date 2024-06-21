using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend;

[Route("/[controller]")]
[ApiController]
public class UserController : ControllerBase
{   
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    [HttpGet("get-user")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetUserById([FromQuery] int id){
        return Ok(_userService.GetUserById(id));
    }

    
    [HttpGet("get-user-by-name")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetUserByName([FromQuery] string name){
        return Ok(_userService.GetUserByName(name));
    }

    
    [HttpGet("get-users")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetUsers(){
        return Ok(_userService.GetAllUsers());
    }
 
    [HttpGet("get-barbers")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetBarbers(){
        return Ok(_userService.GetBarbers());
    }

    [HttpGet("get-clients")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult GetClients(){
        return Ok(_userService.GetClients());
    }
    
    [HttpPost("add-admin")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult AddAdmin([FromBody] AdminDTO adminDTO){
        try{
            _userService.AddAdmin(adminDTO);
            return Created(); 
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex);
        }
        
    }

    [HttpPost("add-barber")]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult AddBarber([FromBody] BarberDTO barberDTO){
        _userService.AddBarber(barberDTO);
        return Created();
    }

    [HttpPost("add-user")]
    [AllowAnonymous]
    public IActionResult AddUser([FromBody] ClientDTO clientDTO){
        _userService.AddUser(clientDTO);
        return Created();
    }

    [HttpPatch("change-password")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult ChangePassword([FromQuery] int id, [FromBody] UserDTO userDTO){
        _userService.UpdatePassword(id, userDTO);
        return NoContent();
    }

    [HttpPatch("change-user-name")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult ChangeUserName([FromQuery] int id, [FromBody] UserDTO userDTO){
        _userService.UpdateUser(id, userDTO);
        return NoContent();
    }

    
    [HttpDelete("delete-user/{id}")]
    [Authorize (Policy = "AdminPolicy")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        _userService.DeleteUser(id);
        return NoContent();
    }

}
