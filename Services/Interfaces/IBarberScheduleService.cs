namespace Rodriguez_Camani_Feresin_Backend;

public interface IBarberScheduleService
{
    public void CreateSchedule(int barberId , BarberScheduleDTO barberScheduleDTO);
    public BarberSchedule GetBarberScheduleByBarberName(string barberName);
    public BarberSchedule GetBarberScheduleById(int barberId);
    public IEnumerable<BarberSchedule> GetAllBarberSchedules();
    public void DeleteSchedule(int barberId);
}
