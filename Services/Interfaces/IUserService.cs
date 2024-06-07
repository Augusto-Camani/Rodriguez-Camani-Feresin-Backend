using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public interface IUserService
{
    public IEnumerable<User> GetAllUsers();
    public IEnumerable<User> GetBarbers();
    public IEnumerable<User> GetClients();
    public User GetUserById(int id);
    public User GetUserByName(string name);
    public void AddUser(ClientDTO clientDTO);
    public void AddBarber(BarberDTO barberDTO);
    public void AddAdmin(AdminDTO adminDTO);
    public void UpdateUser(int id, UserDTO user);
    public void UpdatePassword(int id, UserDTO user);
    public void DeleteUser(int id);
}
