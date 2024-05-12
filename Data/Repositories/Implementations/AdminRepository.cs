using Rodriguez_Camani_Feresin_Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rodriguez_Camani_Feresin_Backend
{
    public class AdminRepository : Repository, IAdminRepository
    {
        public AdminRepository(DbContextCFR context) : base(context)
        {
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
        public IEnumerable<Admin> GetAdmins()
        {
            return _context.Users.Where(u => u.UserType == "Admin").Select(u => (Admin)u).ToList();
        }

        public IEnumerable<Barber> GetBarbers()
        {
            return _context.Users.Where(u => u.UserType == "Barber").Select(u => (Barber)u).ToList();
        }
        public IEnumerable<Client> GetClients()
        {
            return _context.Users.Where(u => u.UserType == "Client").Select(u => (Client)u).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public void DeleteUserById(int userId)
        {
            _context.Remove(GetUserById(userId));
        }
        public void AddAdmin(Admin admin)
        {
            _context.Add(admin);
            _context.SaveChanges();
        }
    }
}