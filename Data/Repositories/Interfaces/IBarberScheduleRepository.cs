namespace Rodriguez_Camani_Feresin_Backend;

public interface IBarberScheduleRepository
{
    public void CreateSchedule(BarberSchedule barberSchedule, IEnumerable<BarberAvailability> barberAvailabilities);
    public BarberSchedule GetBarberScheduleByBarberName(string barberName);
    public BarberSchedule GetBarberScheduleById(int barberId);
    public IEnumerable<BarberSchedule> GetAllBarberSchedules();
    public void DeleteSchedule(int barberId);
}
