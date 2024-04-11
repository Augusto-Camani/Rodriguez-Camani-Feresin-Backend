using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class Repository : IRepository
{
    internal readonly RodriguezCamaniFeresinContext _context;
    public Repository(RodriguezCamaniFeresinContext context)
    {
        _context = context;
    }

    public void SaveChanges(){
        _context.SaveChanges();
    }
}
