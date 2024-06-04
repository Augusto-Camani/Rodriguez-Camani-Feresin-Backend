using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public interface IUserRepository
{
    public IEnumerable<User> GetAllUsers();
    public IEnumerable<User> GetBarbers();
    public IEnumerable<User> GetClients();
    public User GetUserById(int id);
    public User GetUserByName(string name);
    public void AddUser(Client client);
    public void AddBarber(Barber barber);
    public void AddAdmin(Admin admin);
    public void UpdateUser(User user);
     public void UpdatePassword(User user);
    public void DeleteUser(int id);
    BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
}
