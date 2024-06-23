using Swashbuckle.AspNetCore.Annotations;

namespace Rodriguez_Camani_Feresin_Backend;

public class BarberAvailabilityDTO
{
        [SwaggerSchema("The day of the week for the availability slot.")]
        public DaysOfTheWeek DayOfTheWeek { get; set; }

        [SwaggerSchema("The start time for the availability slot.")]
        public TimeSpan StartTime { get; set; }

        [SwaggerSchema("The end time for the availability slot.")]
        public TimeSpan EndTime { get; set; }

        [SwaggerSchema("Indicates if the barber is available during this slot.")]
        public bool IsAvailable { get; set; }
}
