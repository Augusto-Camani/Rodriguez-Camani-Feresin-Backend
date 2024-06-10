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
       _context.Add(admin);
       _context.SaveChanges();
    }

    public void AddBarber(Barber barber)
    {
       _context.Add(barber);
       _context.SaveChanges();
    }

    public void AddUser(Client client)
    {
        _context.Add(client);
        _context.SaveChanges();
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
        //SI hay mas de uno con el mismo nombre tira error.
        return _context.Users.SingleOrDefault(u => u.UserName == name);
    }

    public void UpdatePassword(User user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }

}
