using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IAppointmentService
    {
        public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime);
        public Appointment GetAppointmentById(int appointmentId);
        public void CreateAppointment(AppointmentDTO appointmentDTO);
        public void DeleteAppointment(int appointmentId);

    }
}