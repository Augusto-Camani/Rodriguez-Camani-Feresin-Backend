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
    
    [Authorize]
    [HttpGet("get-user")]
    public IActionResult GetUserById([FromQuery] int id){
        return Ok(_userService.GetUserById(id));
    }

    [Authorize]
    [HttpGet("get-user-by-name")]
    public IActionResult GetUserByName([FromQuery] string name){
        return Ok(_userService.GetUserByName(name));
    }

    [Authorize]
    [HttpGet("get-users")]
    public IActionResult GetUsers(){
        return Ok(_userService.GetAllUsers());
    }

    [Authorize]
    [HttpGet("get-barbers")]
    public IActionResult GetBarbers(){
        return Ok(_userService.GetBarbers());
    }

    [Authorize]
    [HttpGet("get-clients")]
    public IActionResult GetClients(){
        return Ok(_userService.GetClients());
    }

    [Authorize]
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

    [Authorize]
    [HttpPost("add-barber")]
    public IActionResult AddBarber([FromBody] BarberDTO barberDTO){
        _userService.AddBarber(barberDTO);
        return Created();
    }

    [Authorize]
    [HttpPost("add-user")]
    public IActionResult AddUser([FromBody] ClientDTO clientDTO){
        _userService.AddUser(clientDTO);
        return Created();
    }

    [Authorize]
    [HttpPatch("change-password")]
    public IActionResult ChangePassword([FromQuery] int id, [FromBody] UserDTO userDTO){
        _userService.UpdatePassword(id, userDTO);
        return NoContent();
    }

    [Authorize]
    [HttpPatch("change-user-name")]
    public IActionResult ChangeUserName([FromQuery] int id, [FromBody] UserDTO userDTO){
        _userService.UpdateUser(id, userDTO);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("delete-user/{id}")]
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
