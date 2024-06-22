
namespace Rodriguez_Camani_Feresin_Backend;

public class BarberShceduleService : IBarberScheduleService
{   
    private readonly IBarberScheduleRepository _barberScheduleRepository;
    private readonly IUserRepository _userRepository;
    public BarberShceduleService( IBarberScheduleRepository barberScheduleRepository, IUserRepository userRepository)
    {
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

        var availabilitySlots = new List<BarberAvailability>();

        var defaultDays = Enum.GetValues(typeof(DaysOfTheWeek)).Cast<DaysOfTheWeek>().Where(day => day != DaysOfTheWeek.Sunday);

        foreach (var day in defaultDays)
        {
            var availabilityDTO = barberScheduleDTO.AvailabilitySlots.FirstOrDefault(ba => ba.DayOfTheWeek == day);

            if (availabilityDTO == null)
            {
                availabilitySlots.Add(new BarberAvailability
                {
                    DayOfTheWeek = day,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0), 
                    IsAvailable = true 
                });
            }
            else
            {

                availabilitySlots.Add(new BarberAvailability
                {
                    DayOfTheWeek = availabilityDTO.DayOfTheWeek,
                    StartTime = availabilityDTO.StartTime,
                    EndTime = availabilityDTO.EndTime,
                    IsAvailable = availabilityDTO.IsAvailable
                });
            }
        }

        var barberSchedule = new BarberSchedule
        {
            BarberId = barberId,
            CurrentYear = barberScheduleDTO.CurrentYear,
            LastModifiedDate = DateTime.UtcNow,
            AvailabilitySlots = availabilitySlots
        };

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