
using Microsoft.EntityFrameworkCore;

namespace Rodriguez_Camani_Feresin_Backend;

public class BarberScheduleRepository : Repository, IBarberScheduleRepository
{
    public BarberScheduleRepository(DbContextCFR context) : base(context)
    {
    }

    public void CreateSchedule(BarberSchedule barberSchedule, IEnumerable<BarberAvailability> barberAvailabilities)
    {
        barberSchedule.AvailabilitySlots = barberAvailabilities.ToList();
        _context.Add(barberSchedule);
        _context.SaveChanges();
    }

    public void DeleteSchedule(int barberId)
    {
       _context.Remove(GetBarberScheduleById(barberId));
       _context.SaveChanges();
    }

    public IEnumerable<BarberSchedule> GetAllBarberSchedules()
    {
        return _context.BarberSchedules.Include(bs => bs.AvailabilitySlots);
    }

    public BarberSchedule GetBarberScheduleByBarberName(string barberName)
    {
       return _context.BarberSchedules.Include(bs => bs.AvailabilitySlots).SingleOrDefault(bs => bs.Barber.UserName == barberName);
    }

    public BarberSchedule GetBarberScheduleById(int barberId)
    {
        return _context.BarberSchedules.Include(bs => bs.AvailabilitySlots).SingleOrDefault(bs => bs.BarberId == barberId);
    }
}
