using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDTO> GetAppointmentsByBarberId(int barberId);
        IEnumerable<AppointmentSlotDTO> GetAppointmentsByBarberAndDate(int barberId, DateTime date);
        AppointmentDTO GetAppointmentById(int appointmentId);
        void CreateAppointment(AppointmentDTO appointmentCreateDTO);
        void DeleteAppointment(int appointmentId);
    }
}