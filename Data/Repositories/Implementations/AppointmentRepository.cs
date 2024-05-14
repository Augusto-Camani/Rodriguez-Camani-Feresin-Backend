using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Implementations
{
    public class AppointmentRepository : Repository, IAppointmentRepository
    {
        public AppointmentRepository(DbContextCFR context) : base(context)
        {
        }

        public void CreateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
            //_context.Appointments.Add(appointment);
            //_context.SaveChanges();
        }
        public void DeleteUserById(int appointmentid)
        {
            throw new NotImplementedException();
            //var appointmentToDelete = _context.Appointments.Find(appointmentId);
            //if (appointmentToDelete != null)
            //{
            //    _context.Appointments.Remove(appointmentToDelete);
            //    _context.SaveChanges();
            //}
        }
    }
}