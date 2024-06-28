namespace Rodriguez_Camani_Feresin_Backend;

public interface IAppointmentScheduleAdapter
{
    public IEnumerable<AppointmentSlotDTO> GetAvailableSlotsForBarberAndDate(int barberId, DateTime date);
}
