using Microsoft.AspNetCore.Mvc;

namespace Rodriguez_Camani_Feresin_Backend;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{   
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IUserService userService ,IAuthenticationService authenticationService)
    {
        _userService = userService;
        _authenticationService = authenticationService;
    }

    
    [HttpPost]
    public IActionResult Loggin([FromBody] UserDTO userDTO){
        var user = _userService.GetUserByName(userDTO.UserName);
        if(user != null)
        {
            return Ok();
        }

        return NotFound();
    }
}
