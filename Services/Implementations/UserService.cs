using AutoMapper;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class UserService : IUserService
{   
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidationService _validationService;
    private readonly IPasswordHasher _passwordHasher;
    public UserService(IUserRepository userRepository, IMapper mapper, IValidationService validationService, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validationService = validationService;
        _passwordHasher = passwordHasher;
    }
    public void AddAdmin(AdminDTO adminDTO)
    {   
         if (!_validationService.ValidateEmail(adminDTO.Email) || !_validationService.ValidatePassword(adminDTO.PasswordHash) )
        {
            throw new ArgumentException("Invalid email address or password.");
        }

        var admin = _mapper.Map<Admin>(adminDTO);
        admin.PasswordHash = _passwordHasher.HashPassword(adminDTO.PasswordHash);
        _userRepository.AddAdmin(admin);
    }

    public void AddBarber(BarberDTO barberDTO)
    {
        if (!_validationService.ValidateEmail(barberDTO.Email) || !_validationService.ValidatePassword(barberDTO.PasswordHash))
        {
            throw new ArgumentException("Invalid email address or password.");
        }

        var barber = _mapper.Map<Barber>(barberDTO);
        barber.PasswordHash = _passwordHasher.HashPassword(barberDTO.PasswordHash);
        _userRepository.AddBarber(barber);
    }

    public void AddUser(ClientDTO clientDTO)
    {
        if (!_validationService.ValidateEmail(clientDTO.Email) || !_validationService.ValidatePassword(clientDTO.PasswordHash))
        {
            throw new ArgumentException("Invalid email address or password.");
        }

        var client = _mapper.Map<Client>(clientDTO);
        client.PasswordHash = _passwordHasher.HashPassword(clientDTO.PasswordHash);
        _userRepository.AddUser(client);
    }

    public void DeleteUser(int id)
    {
       _userRepository.DeleteUser(id);
    }

    public IEnumerable<User> GetAllUsers()
    {
       return _userRepository.GetAllUsers();
    }

    public IEnumerable<User> GetBarbers()
    {
      return _userRepository.GetBarbers();
    }

    public IEnumerable<User> GetClients()
    {
       return _userRepository.GetClients();
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public User GetUserByName(string name)
    {
       return _userRepository.GetUserByName(name);
    }

    public void UpdatePassword(int id, UserDTO userDTO)
    {
        
        var existingUser = _userRepository.GetUserById(id);
        if (existingUser == null)
        {
            throw new Exception("Usuario inexistente");
        }

        
        if (!_validationService.ValidatePassword(userDTO.PasswordHash))
        {
            throw new ArgumentException("Invalid password.");
        }

        
        existingUser.PasswordHash = _passwordHasher.HashPassword(userDTO.PasswordHash);

        
        _userRepository.UpdatePassword(existingUser);
    }


    public void UpdateUser(int id, UserDTO userDTO)
    {
        // Obtener el usuario existente
        var existingUser = _userRepository.GetUserById(id);
        if (existingUser == null)
        {
            throw new Exception("Usuario inexistente");
        }
        existingUser.UserName = userDTO.UserName;
        _userRepository.UpdateUser(existingUser);
    }

}
