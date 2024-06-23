using Swashbuckle.AspNetCore.Filters;

namespace Rodriguez_Camani_Feresin_Backend;

public class BarberScheduleDTOExample : IExamplesProvider<BarberScheduleDTO>
{
    public BarberScheduleDTO GetExamples()
    {
        return new BarberScheduleDTO
        {
            BarberId = 1,
            CurrentYear = 2024,
            AvailabilitySlots = new List<BarberAvailabilityDTO>
            {
                new BarberAvailabilityDTO
                {
                    DayOfTheWeek = DaysOfTheWeek.Tuesday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    IsAvailable = true
                },
                new BarberAvailabilityDTO
                {
                    DayOfTheWeek = DaysOfTheWeek.Wednesday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    IsAvailable = true
                },
                new BarberAvailabilityDTO
                {
                    DayOfTheWeek = DaysOfTheWeek.Thursday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    IsAvailable = true
                },
                new BarberAvailabilityDTO
                {
                    DayOfTheWeek = DaysOfTheWeek.Friday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    IsAvailable = true
                },
                new BarberAvailabilityDTO
                {
                    DayOfTheWeek = DaysOfTheWeek.Saturday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    IsAvailable = true
                },
                new BarberAvailabilityDTO
                {
                    DayOfTheWeek = DaysOfTheWeek.Sunday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    IsAvailable = true
                }
            }
        };
    }
}
