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

        public IEnumerable<AppointmentDTO> GetAppointmentsByBarberId(int barberId)
        {
            var appointments = _appointmentRepository.GetAppointmentByBarberId(barberId);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public IEnumerable<AppointmentDTO> GetAppointmentsByBarberAndDate(int barberId, DateTime date)
        {
            var appointments = _appointmentRepository.GetAvailableBarberAppointmentsByDate(barberId, date);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public AppointmentDTO GetAppointmentById(int appointmentId)
        {
            var appointment = _appointmentRepository.GetAppointmentById(appointmentId);
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public void CreateAppointment(AppointmentDTO appointmentCreateDTO)
        {
            var newAppointment = _mapper.Map<Appointment>(appointmentCreateDTO);
            _appointmentRepository.CreateAppointment(newAppointment);
        }

        public void DeleteAppointment(int appointmentId)
        {
            _appointmentRepository.DeleteAppointment(appointmentId);
        }
    }
}