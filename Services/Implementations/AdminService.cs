
namespace Rodriguez_Camani_Feresin_Backend;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository= adminRepository;
    }

    public IEnumerable<Admin> GetAll()
    {
        return _adminRepository.GetAll();
    }
}
