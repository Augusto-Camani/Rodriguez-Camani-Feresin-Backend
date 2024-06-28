using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Implementations
{
    public class AppointmentRepository : Repository, IAppointmentRepository
    {
        public AppointmentRepository(DbContextCFR context) : base(context)
        {
        }
        public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId , DateTime dateTime)
        {
           return _context.Appointments.Where(a => a.BarberId == barberId && a.BarberAvailability.DayOfTheWeek.Equals(dateTime.DayOfWeek));
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _context.Appointments.SingleOrDefault(a => a.AppointmentId == appointmentId);
        }

        public Appointment GetAppointmentByBarberId(int barberId)
        {
            return _context.Appointments.SingleOrDefault(a => a.BarberId == barberId);
        }
        public void CreateAppointment(Appointment appointment)
        {
            _context.Add(appointment);
            _context.SaveChanges();
        }
        public void DeleteAppointment(int appointmentid)
        {
            _context.Remove(GetAppointmentById(appointmentid));
            _context.SaveChanges();
        }
    }
}