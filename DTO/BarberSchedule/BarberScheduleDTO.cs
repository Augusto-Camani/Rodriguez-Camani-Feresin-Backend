using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
namespace Rodriguez_Camani_Feresin_Backend;

public class BarberScheduleDTO
{
    [SwaggerSchema("The unique identifier of the barber.")]
    public int BarberId { get; set; }
        
    [SwaggerSchema("The current year for the schedule.")]
    public int CurrentYear { get; set; }
        
    [SwaggerSchema("The list of availability slots for the barber.")]
    public List<BarberAvailabilityDTO> AvailabilitySlots { get; set; }
}
