using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public interface IAdminService
{
    public IEnumerable<User> GetUsers();
    public IEnumerable<Admin> GetAdmins();
    public IEnumerable<Barber> GetBarbers();
    public IEnumerable<Client> GetClients();
    public User GetUserById(int id);
    public void DeleteUserById(int id);
    public void AddAdmin(Admin admin);
}
