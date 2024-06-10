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
    public IActionResult GetUserById([FromQuery] int id){
        return Ok(_userService.GetUserById(id));
    }

    [HttpGet("get-user-by-name")]
    public IActionResult GetUserByName([FromQuery] string name){
        return Ok(_userService.GetUserByName(name));
    }

    [HttpGet("get-users")]
    public IActionResult GetUsers(){
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("get-barbers")]
    public IActionResult GetBarbers(){
        return Ok(_userService.GetBarbers());
    }

    [HttpGet("get-clients")]
    public IActionResult GetClients(){
        return Ok(_userService.GetClients());
    }

    [HttpPost("add-admin")]
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
    public IActionResult AddBarber([FromBody] BarberDTO barberDTO){
        _userService.AddBarber(barberDTO);
        return Created();
    }

    [HttpPost("add-user")]
    public IActionResult AddUser([FromBody] ClientDTO clientDTO){
        _userService.AddUser(clientDTO);
        return Created();
    }

    [HttpPatch("change-password")]
    public IActionResult ChangePassword([FromQuery] int id, [FromBody] UserDTO userDTO){
        _userService.UpdatePassword(id, userDTO);
        return NoContent();
    }

    [HttpPatch("change-user-name")]
    public IActionResult ChangeUserName([FromQuery] int id, [FromBody] UserDTO userDTO){
        _userService.UpdateUser(id, userDTO);
        return NoContent();
    }

    [HttpDelete("delete-user")]
    public IActionResult DeleteUser([FromQuery] int id){
        _userService.DeleteUser(id);
        return NoContent();
    }
}
