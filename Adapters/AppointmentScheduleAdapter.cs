using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class AppointmentScheduleAdapter : IAppointmentScheduleAdapter
    {
        private readonly IBarberScheduleRepository _barberScheduleRepository;

        public AppointmentScheduleAdapter(IBarberScheduleRepository barberScheduleRepository)
        {
            _barberScheduleRepository = barberScheduleRepository;
        }
        public IEnumerable<AppointmentSlotDTO> GetAvailableSlotsForBarberAndDate(int barberId, DateTime date)
        {
            var barberSchedule = _barberScheduleRepository.GetBarberScheduleById(barberId);
            if (barberSchedule == null)
            {
                throw new Exception($"Barber schedule not found for barberId: {barberId}");
            }

            var dayOfWeek = ConvertToDaysOfTheWeek(date.DayOfWeek);
            var availabilitySlots = barberSchedule.AvailabilitySlots
                .Where(slot => slot.DayOfTheWeek == dayOfWeek)
                .ToList();

            var appointmentSlots = new List<AppointmentSlotDTO>();

            foreach (var slot in availabilitySlots)
            {
                var startDateTime = date.Date + slot.StartTime;
                var endDateTime = date.Date + slot.EndTime;

                while (startDateTime < endDateTime)
                {
                    var nextHour = startDateTime.AddHours(1);
                    if (nextHour > endDateTime)
                    {
                        break;
                    }

                    appointmentSlots.Add(new AppointmentSlotDTO
                    {
                        StartTime = startDateTime,
                        EndTime = nextHour,
                        IsAvailable = slot.IsAvailable
                    });

                    startDateTime = nextHour;
                }
            }

            return appointmentSlots;
        }
        private DaysOfTheWeek ConvertToDaysOfTheWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Sunday => DaysOfTheWeek.Sunday,
                DayOfWeek.Monday => DaysOfTheWeek.Monday,
                DayOfWeek.Tuesday => DaysOfTheWeek.Tuesday,
                DayOfWeek.Wednesday => DaysOfTheWeek.Wednesday,
                DayOfWeek.Thursday => DaysOfTheWeek.Thursday,
                DayOfWeek.Friday => DaysOfTheWeek.Friday,
                DayOfWeek.Saturday => DaysOfTheWeek.Saturday,
                _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
            };
        }
    }
}