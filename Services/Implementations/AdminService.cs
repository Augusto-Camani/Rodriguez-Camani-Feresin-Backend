

using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository= adminRepository;
    }

    public User GetUserById(int id)
    {
       return _adminRepository.GetUserById(id);
    }

    public IEnumerable<User> GetUsers()
    {
        return _adminRepository.GetUsers();
    }
    public IEnumerable<Admin> GetAdmins()
    {
        return _adminRepository.GetAdmins();
    }

    public IEnumerable<Barber> GetBarbers()
    {
        return _adminRepository.GetBarbers();
    }

    public IEnumerable<Client> GetClients()
    {
        return _adminRepository.GetClients();
    }

    public void AddAdmin(Admin admin)
    {
        _adminRepository.AddAdmin(admin);
    }

    public void DeleteUserById(int id)
    {
        _adminRepository.DeleteUserById(id);
    }

}
