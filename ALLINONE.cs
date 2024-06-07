namespace Rodriguez_Camani_Feresin_Backend;

public class ALLINONE
{   
    //INTERFACE

// public interface IAuthenticationService
// {
//     BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
// }

    //SERVICE

// public class AuthenticationService : IAuthenticationService
// {
//     private readonly IUserRepository _userRepository;
//     private readonly IPasswordHasher _passwordHasher;

//     public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher)
//     {
//         _userRepository = userRepository;
//         _passwordHasher = passwordHasher;
//     }

//     public BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequest)
//     {
//         var user = _userRepository.GetUserByName(authenticationRequest.UserName);
//         if (user == null)
//         {
//             return new BaseResponse { Result = false, Message = "wrong username" };
//         }

//         var isPasswordValid = _passwordHasher.Verify(user.PasswordHash, authenticationRequest.Password);
//         if (!isPasswordValid)
//         {
//             return new BaseResponse { Result = false, Message = "wrong password" };
//         }

//         return new BaseResponse { Result = true, Message = "success" };
//     }
// }

    //CONTROLLER

// [Route("api/authentication")]
// [ApiController]
// public class AuthenticationController : ControllerBase
// {
//     private readonly IAuthenticationService _authenticationService;
//     private readonly IUserService _userService;
//     private readonly IConfiguration _config;

//     public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IConfiguration config)
//     {
//         _authenticationService = authenticationService;
//         _userService = userService;
//         _config = config;
//     }

//     [HttpPost]
//     public IActionResult Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
//     {
//         BaseResponse validarUsuarioResult = _authenticationService.ValidateUser(authenticationRequestBody);
//         if (validarUsuarioResult.Message == "wrong username")
//         {
//             return NotFound("User not found."); // 404 Not Found si el usuario no existe
//         }
//         else if (validarUsuarioResult.Message == "wrong password")
//         {
//             return Unauthorized("Invalid password."); // 401 Unauthorized si la contraseña es incorrecta
//         }

//         if (validarUsuarioResult.Result)
//         {
//             User user = _userService.GetUserByName(authenticationRequestBody.UserName);
//             var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
//             var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

//             var claimsForToken = new List<Claim>
//             {
//                 new Claim("sub", user.Id.ToString()),
//                 new Claim("username", user.UserName),
//                 new Claim("usertype", user.UserType.ToString())
//             };

//             var jwtSecurityToken = new JwtSecurityToken(
//                 _config["Authentication:Issuer"],
//                 _config["Authentication:Audience"],
//                 claimsForToken,
//                 DateTime.UtcNow,
//                 DateTime.UtcNow.AddHours(1),
//                 signature);

//             string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
//             return Ok(tokenToReturn); // 200 OK si la autenticación es exitosa
//         }

//         return BadRequest(); // 400 Bad Request si algo más falla
//     }
// }

        //DTO'S

// public class AuthenticationRequestBody
// {
//     [Required]
//     public string UserName { get; set; }

//     [Required]
//     public string Password { get; set; }
// }

// public class BaseResponse
// {
//     public bool Result { get; set; }
//     public string Message { get; set; }
// }


        //CONFIG AND DEPENDENCIES 

// public void ConfigureServices(IServiceCollection services)
// {
//     // Otros servicios
//     services.AddScoped<IUserService, UserService>();
//     services.AddScoped<IAuthenticationService, AuthenticationService>();
//     services.AddScoped<IPasswordHasher, PasswordHasher>();
//     services.AddScoped<IValidationService, ValidationService>();
    
//     // Configuración JWT
//     var key = Encoding.ASCII.GetBytes(Configuration["Authentication:SecretForKey"]);
//     services.AddAuthentication(x =>
//     {
//         x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     }).AddJwtBearer(x =>
//     {
//         x.RequireHttpsMetadata = false;
//         x.SaveToken = true;
//         x.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(key),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });
// }

}
