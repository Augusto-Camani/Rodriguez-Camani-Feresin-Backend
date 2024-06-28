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
        private readonly IAppointmentScheduleAdapter _appointmentScheduleAdapter;

        public AppointmentService(IAppointmentRepository appointmentRepository,IMapper mapper,IAppointmentScheduleAdapter appointmentScheduleAdapter)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _appointmentScheduleAdapter = appointmentScheduleAdapter;
        }
        public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime)
        {
            var appointments = _appointmentRepository.GetAvailableBarberAppointmentsByDate(barberId, dateTime);
            return _mapper.Map<IEnumerable<Appointment>>(appointments);
        }
        public IEnumerable<AppointmentDTO> GetAppointmentsByBarberId(int barberId)
        {
            var appointments = _appointmentRepository.GetAppointmentByBarberId(barberId);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public IEnumerable<AppointmentSlotDTO> GetAppointmentsByBarberAndDate(int barberId, DateTime date)
        {
            return _appointmentScheduleAdapter.GetAvailableSlotsForBarberAndDate(barberId, date);
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