

using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository= adminRepository;
    }

    public void AddAdmin(Admin admin)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Admin> GetAdmins()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Barber> GetBarbers()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Client> GetClients()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetUsers()
    {
        throw new NotImplementedException();
    }
}
