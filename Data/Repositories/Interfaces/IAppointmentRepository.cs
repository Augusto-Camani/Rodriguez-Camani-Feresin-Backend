using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime);
        public Appointment GetAppointmentById(int appointmentId);
        public void CreateAppointment(Appointment appointment);
        public void DeleteUserById(int appointmentid);
    }
}