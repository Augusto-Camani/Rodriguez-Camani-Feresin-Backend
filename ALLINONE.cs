namespace Rodriguez_Camani_Feresin_Backend;

public class ALLINONE
{

    //  public class UserRepository : Repository, IUserRepository
    //     {
    //         public UserRepository(DBContext.AppDBContext context) : base(context) 
    //         {

    //         }
    //         public IEnumerable<User> GetAll()
    //         {
    //             return _context.Users;
    //         }

    //         public User GetById(int id)
    //         {
    //            return _context.Users.Find(id);
    //         }

    //         public User GetByUserName(string name)
    //         {
    //             return _context.Users.SingleOrDefault( u => u.UserName == name);
    //         }
    //         public void AddClient(User user)
    //         {
    //             _context.Add(user);
    //             _context.SaveChanges();
    //         }

    //         public void AddAdmin(User admin) 
    //         {
    //             _context.Add(admin);
    //             _context.SaveChanges();
    //         }

    //         public void Update(User user)
    //         {
    //            _context.Update(user);
    //            _context.SaveChanges();
    //         }
    //         public void Delete(int id)
    //         {
    //             _context.Remove(GetById(id));
    //             _context.SaveChanges();
    //         }

    //         public BaseResponse ValidateUser(AuthenticationRequestBody authRequestBody)
    //         {
    //                 BaseResponse response = new BaseResponse();
    //                 User? userForLogin = _context.Users.SingleOrDefault(u => u.UserName == authRequestBody.UserName);
    //                 if (userForLogin != null)
    //                 {
    //                     if (userForLogin.Password == authRequestBody.Password)
    //                     {
    //                         response.Result = true;
    //                         response.Message = "loging Succesfull";
    //                     }
    //                     else
    //                     {
    //                         response.Result = false;
    //                         response.Message = "wrong password";
    //                     }
    //                 }
    //                 else
    //                 {
    //                     response.Result = false;
    //                     response.Message = "wrong email";
    //                 }
    //                 return response;
    //         }
    //     }

    // public interface IUserRepository
    // {
    //     public IEnumerable<User> GetAll();
    //     public User GetById(int id);
    //     public User GetByUserName(string name);
    //     public void AddClient(User user);
    //     public void AddAdmin(User admin);
    //     public void Update(User user);
    //     public void Delete(int id);
    //     BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    // }

    //     public class UserService : IUserService
    // {
    //     private readonly IMapper _mapper;
    //     private readonly IUserRepository _userRepository;

    //     public UserService(IUserRepository userRepository, IMapper mapper)
    //     {
    //         _userRepository = userRepository;
    //         _mapper = mapper;
    //     }

    //     public IEnumerable<User> GetAll()
    //     {
    //         return _userRepository.GetAll();
    //     }
    //     public User GetById(int id)
    //     {
    //         return  _userRepository.GetById(id);
    //     }
    //     public User GetByUserName(string name)
    //     {
    //         return _userRepository.GetByUserName(name);
    //     }
    //     public void AddClient(UserDTO userDTO)
    //     {
    //         var user = _mapper.Map<Client>(userDTO);
    //         _userRepository.AddClient(user);
    //     }

    //     public void AddAdmin(UserDTO userDTO)
    //     {
    //         var admin = _mapper.Map<Admin>(userDTO);
    //         _userRepository.AddAdmin(admin);
    //     }

    //     public void Update(int id, UserDTO userDTO)
    //     {
    //         var existingUser = _userRepository.GetById(id);

    //         if (existingUser == null)
    //         {
    //             // Manejar el caso en el que el producto no existe
    //             throw new Exception("Producto no encontrado");
    //         }

    //         // Mapear las propiedades relevantes del DTO a la entidad existente
    //         existingUser.UserName = userDTO.UserName;
    //         existingUser.Email = userDTO.Email;
    //         existingUser.Password = userDTO.Password;

    //         // Actualizar la entidad en el repositorio
    //         _userRepository.Update(existingUser);
    //     }

    //     public void Delete(int id)
    //     {
    //         _userRepository.Delete(id);
    //     }
    // }

    // public interface IUserService
    // {
    //     public IEnumerable<User> GetAll();
    //     public User GetById(int id);
    //     public User GetByUserName(string name);
    //     public void AddClient(UserDTO userDTO);
    //     public void AddAdmin(UserDTO userDTO);
    //     public void Update(int id, UserDTO userDTO);
    //     public void Delete(int id);
    // }

    //     [ApiController]
    // [Route("[controller]")]

    // public class UserController : ControllerBase
    // {
    //     private readonly IUserService _userService;

    //     public UserController(IUserService userService)
    //     {
    //         _userService = userService;
    //     }

    //     [HttpGet("GetAll")]
    //     [Authorize ("AdminPolicy")]
    //     public IActionResult GetAll()
    //     {
    //         try
    //         {
    //             return Ok(_userService.GetAll());
    //         }
    //         catch
    //         {
    //             return BadRequest();
    //         }
    //     }

    //     [HttpGet("GetById/{id}")]
    //     [Authorize("AdminPolicy")]
    //     public IActionResult GetById(int id)
    //     {
    //         try
    //         {
    //             var product = _userService.GetById(id);

    //             if (product == null)
    //             {
    //                 return NotFound();
    //             }

    //             return Ok(product);
    //         }
    //         catch (Exception)
    //         {
    //             return BadRequest();
    //         }
    //     }

    //     [HttpGet("GetByName/{name}")]
    //     [Authorize("AdminPolicy")]
    //     public IActionResult GetByName(string name)
    //     {
    //         try
    //         {
    //             return Ok(_userService.GetByUserName(name));
    //         }
    //         catch
    //         {
    //             return NotFound();
    //         }
    //     }

    //     [HttpPost("CreateClient")]
    //     [Authorize("BothPolicy")]
    //     public IActionResult CreateClient([FromBody] UserDTO userDTO)
    //     {

    //         _userService.AddClient(userDTO);
    //         return StatusCode(201);
    //     }

    //     [HttpPost("CreateAdmin")]
    //     [Authorize("AdminPolicy")]
    //     public IActionResult CreateAdmin([FromBody] UserDTO adminDTO)
    //     {

    //         _userService.AddAdmin(adminDTO);
    //         return StatusCode(201);
    //     }


    //     [HttpPut("UpdateUser/{id}")]
    //     [Authorize("AdminPolicy")]
    //     public IActionResult Update(int id, [FromBody] UserDTO userDTO)
    //     {
    //         try
    //         {
    //             _userService.Update(id, userDTO);
    //             return NoContent();
    //         }
    //         catch (Exception ex)
    //         {
    //             // Dependiendo del tipo de excepción que arroje el servicio, puedes personalizar el manejo de errores aquí
    //             return BadRequest(ex.Message);
    //         }
    //     }

    //     [HttpDelete("DeleteUser/{id}")]
    //     [Authorize("AdminPolicy")]
    //     public IActionResult DeleteProduct(int id)
    //     {
    //         try
    //         {
    //             _userService.Delete(id);
    //             return NoContent();
    //         }
    //         catch
    //         {
    //             return BadRequest();
    //         }
    //     }
    // }

    // [Route("api/authentication")]
    // [ApiController]
    // public class AuthenticationController : ControllerBase
    // {
    //     private readonly IConfiguration _config;
    //     private readonly IAuthenticationService _authenticationService;
    //     private readonly IUserService _userService;
    //     public AuthenticationController(IConfiguration config, IAuthenticationService autenticacionService, IUserService userService)
    //     {
    //         _config = config; //Hacemos la inyección para poder usar el appsettings.json.
    //         this._authenticationService = autenticacionService; //Inyectamos el autenticador.
    //         this._userService = userService; //Hacemos la inyección del servicio de usuario.
    //     }

    //     [HttpPost]
    //     public IActionResult Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
    //     {
    //         BaseResponse validarUsuarioResult = _authenticationService.ValidateUser(authenticationRequestBody); //El método post devolverá una Respuesta mockeada, alojada en los models.
    //         if (validarUsuarioResult.Message == "wrong username")
    //         {
    //             return BadRequest(validarUsuarioResult.Message); //Devolvemos la respuesta de error.
    //         }
    //         else if (validarUsuarioResult.Message == "wrong password")
    //         {
    //             return Unauthorized(); //Devolvemos un 403 Status code (sin autorización).
    //         }
    //         if (validarUsuarioResult.Result)
    //         {
    //             User? user = _userService.GetByUserName(authenticationRequestBody.UserName); //Se busca un usuario por su nombre.
    //             var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Creamos una secret key para hashearla dentro del Token.

    //             var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); //Hasheamos la Secret Key + la Payload + el Header.

    //             var claimsForToken = new List<Claim>();                        //Creamos una lista de Claims (Requisitos) 
    //             claimsForToken.Add(new Claim("sub", user.Id.ToString()));       //Son piezas de informacíon necesarias para concretar la creación del Token y la autorización.
    //             claimsForToken.Add(new Claim("username", user.UserName));
    //             claimsForToken.Add(new Claim("usertype", user.UserType.ToString()));

    //             var jwtSecurityToken = new JwtSecurityToken( //Creamos el token con todo lo necesario para que funcione.
    //                 _config["Authentication:Issuer"],
    //                 _config["Authentication:Audience"],
    //                 claimsForToken,
    //                 DateTime.UtcNow,
    //                 DateTime.UtcNow.AddHours(1), //Le damos una hora de validez al token, para que no se venza.
    //                 signature);

    //             string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken); //Escribimos el token mediante el método WriteToken().
    //             return Ok(tokenToReturn); //Devolvemos el TOKEN al pegarle al endpoint.
    //         }
    //         return BadRequest(); //Si no funciona, devolvemos un Bad Request (Status code 400).
    //     }
    // }

    //     public class AuthenticationService : IAuthenticationService
    // {
    //     private readonly IUserRepository _userRepository;

    //     public AuthenticationService(IUserRepository userRepository)
    //     {
    //         _userRepository = userRepository;
    //     }

    //     public BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequest)
    //     {
    //         if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password)) //Verificamos que el usuario y la contraseña no sean NULAS.
    //             return null;

    //         return _userRepository.ValidateUser(authenticationRequest);
    //     }
    // }

    //     public interface IAuthenticationService
    // {
    //     BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    // }

    // public class AuthenticationRequestBody //Este elemento funciona igual que un DTO, lo utilizamos para pasar información personalizada a un objeto.
    // {
    //     [Required]
    //     public string? UserName { get; set; }
    //     [Required]
    //     public string? Password { get; set; }
    // }
    // public class BaseResponse //Es igual que un DTO.
    // {
    //     public bool Result { get; set; }
    //     public string Message { get; set; }
    // }

    //  public class ClientService : IClientService
    // {
    //     private readonly IClientRepository _clientRepository;
    //     //private readonly IMapper _mapper;
    //     public ClientService(IClientRepository clientRepository)
    //     {
    //         _clientRepository = clientRepository;

    //     }
    //     public void CreateClient(ClientDTO clientdto)
    //     {
    //         //if (!ValidatePassword(clientdto.Password))
    //         //{
    //         //    throw new Exception("The password does not meet the requirements. it must have at least one number and one special character");
    //         //}
    //         //var newUser = _mapper.Map<Client>(userDto);
    //         //_ClientRepository.CreateClient(newUser);
    //     }
    //     public void UpdateClient(int id, ClientDTO user)
    //     {
    //         //var existsUser = _clientRepository.GetUserById(id);
    //         //if (existsUser == null)
    //         //{
    //         //    throw new Exception("Usuario NO encontrado");
    //         //}
    //         //if (!ValidatePassword(user.Password))
    //         //{
    //         //    throw new Exception("The password does not meet the requirements.");
    //         //}
    //         //existsUser.UserName = user.UserName;
    //         //existsUser.Email = user.Email;

    //         //_userRepository.UpdateUser(existsUser);
    //         //_userRepository.SaveChanges();
    //     }
    //     //public void UpdateReview(int id, ReviewDto reviewdto)
    //     //{
    //     //    throw new NotImplementedException();
    //     //}
    //     //public void CreateReview(ReviewDTO, int idTurno)
    //     //{
    //     //    throw new NotImplementedException();
    //     //}
    // }

}
