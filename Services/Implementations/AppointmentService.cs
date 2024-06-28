using AutoMapper;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;

        }
        public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime)
        {
            return _appointmentRepository.GetAvailableBarberAppointmentsByDate(barberId, dateTime);
        }
        public void CreateAppointment(AppointmentDTO appointmentDTO)
        {   
            var newAppointment = _mapper.Map<Appointment>(appointmentDTO);
            _appointmentRepository.CreateAppointment(newAppointment);
        }

        public void DeleteAppointment(int appointmentId)
        {
            _appointmentRepository.DeleteUserById(appointmentId);
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _appointmentRepository.GetAppointmentById(appointmentId);
        }
    }
}