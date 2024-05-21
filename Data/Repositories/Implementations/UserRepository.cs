using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class UserRepository : IUserRepository
{
    private readonly DbContextCFR _context;
    public UserRepository(DbContextCFR context)
    {
        _context = context;
    }

    public void AddAdmin(Admin admin)
    {
        throw new NotImplementedException();
    }

    public void AddBarber(Barber barber)
    {
        throw new NotImplementedException();
    }

    public void AddUser(Client client)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int id)
    {
        _context.Remove(GetUserById(id));
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users;
    }

    public IEnumerable<User> GetBarbers()
    {
        return _context.Barbers;
    }

    public IEnumerable<User> GetClients()
    {
        return _context.Clients;
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public User GetUserByName(string name)
    {
        return _context.Users.SingleOrDefault(u => u.UserName == name);
    }

    public void UpdateUser(int id, User user)
    {
        throw new NotImplementedException();
    }

    public BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody)
    {
        throw new NotImplementedException();
    }
}
