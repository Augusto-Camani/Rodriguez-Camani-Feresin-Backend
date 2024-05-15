using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IAppointmentService
    {
        public void CreateAppointment(AppointmentDTO appointmentDto);
        public void DeleteAppointment(int appointmentId);

    }
}