namespace Rodriguez_Camani_Feresin_Backend;

public interface IAppointmentScheduleAdapter
{
    Task<IEnumerable<Appointment>> GetAvailableAppointmentsForBarberAndDate(int barberId, DateTime date);
}
