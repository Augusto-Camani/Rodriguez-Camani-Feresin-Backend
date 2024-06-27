using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

        }
        public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate()
        {
            throw new NotImplementedException();
        }
        public void CreateAppointment(AppointmentDTO appointmentDto)
        {
            throw new NotImplementedException();
            //var newAppointment = _mapper.Map<Appointment>(appointmentDto);
            //_appointmentRepository.CreateAppointment(newAppointment);
        }

        public void DeleteAppointment(int appointmentId)
        {
            throw new NotImplementedException();
            //_appointmentRepository.DeleteAppointment(appointmentId);
        }
    }
}