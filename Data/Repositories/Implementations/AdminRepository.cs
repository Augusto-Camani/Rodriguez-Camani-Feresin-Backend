using Rodriguez_Camani_Feresin_Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rodriguez_Camani_Feresin_Backend
{
    public class AdminRepository : Repository, IAdminRepository
    {
        public AdminRepository(RodriguezCamaniFeresinContext context) : base(context)
        {
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Users.Where(u => u.UserType == "Admin").Select(u => (Admin)u).ToList();
        }

        public Admin GetAdminById(int AdminId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == AdminId && u.UserType == "Admin") as Admin;
        }
        public void AddAdmin(Admin admin)
        {
            _context.Add(admin);
            _context.SaveChanges();
        }
    }
}