namespace Rodriguez_Camani_Feresin_Backend;

public interface IAdminRepository
{
    public IEnumerable<Admin> GetAll();

    public Admin GetAdminById(int id);
    public void AddAdmin(Admin admin);
}
