
namespace Rodriguez_Camani_Feresin_Backend;

public class BarberShceduleService : IBarberScheduleService
{   
    private readonly IBarberScheduleFactory _barberShceduleFactory;
    private readonly IBarberScheduleRepository _barberScheduleRepository;
    private readonly IUserRepository _userRepository;
    public BarberShceduleService( IBarberScheduleFactory barberScheduleFactory ,IBarberScheduleRepository barberScheduleRepository, IUserRepository userRepository)
    {
        _barberShceduleFactory = barberScheduleFactory;
        _barberScheduleRepository = barberScheduleRepository;
        _userRepository = userRepository;
    }
    public void CreateSchedule(int barberId, BarberScheduleDTO barberScheduleDTO)
    {
         var barber = _userRepository.GetUserById(barberId);
            if (barber == null)
            {
                throw new Exception("Barber not found.");
            }

            var barberSchedule = _barberShceduleFactory.CreateBarberSchedule(barberId);

            foreach (var slot in barberScheduleDTO.AvailabilitySlots)
            {
                var existingSlot = barberSchedule.AvailabilitySlots.FirstOrDefault(s => s.DayOfTheWeek == slot.DayOfTheWeek);
                if (existingSlot != null)
                {
                    existingSlot.StartTime = slot.StartTime;
                    existingSlot.EndTime = slot.EndTime;
                    existingSlot.IsAvailable = slot.IsAvailable;
                }
            }

            _barberScheduleRepository.CreateSchedule(barberSchedule, barberSchedule.AvailabilitySlots);
    }
    public BarberSchedule GetBarberScheduleByBarberName(string barberName)
    {
        return _barberScheduleRepository.GetBarberScheduleByBarberName(barberName);
    }

    public BarberSchedule GetBarberScheduleById(int barberId)
    {
        return _barberScheduleRepository.GetBarberScheduleById(barberId);
    }

    public IEnumerable<BarberSchedule> GetAllBarberSchedules()
    {
        return _barberScheduleRepository.GetAllBarberSchedules();
    }

    public void DeleteSchedule(int barberId)
    {
        _barberScheduleRepository.DeleteSchedule(barberId);
    }
}