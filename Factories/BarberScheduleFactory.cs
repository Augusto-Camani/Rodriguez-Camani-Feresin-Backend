namespace Rodriguez_Camani_Feresin_Backend;

public class BarberScheduleFactory : IBarberScheduleFactory
{
    public BarberSchedule CreateBarberSchedule(int barberId)
    {

        var defaultDays = Enum.GetValues(typeof(DaysOfTheWeek)).Cast<DaysOfTheWeek>().Where(day => day != DaysOfTheWeek.Monday);

        var availabilitySlots = new List<BarberAvailability>();
       
        foreach (var day in defaultDays)
        {
            availabilitySlots.Add(new BarberAvailability
            {
                DayOfTheWeek = day,
                StartTime = new TimeSpan(9, 0, 0),   
                EndTime = new TimeSpan(17, 0, 0),  
                IsAvailable = true                 
            });
        }

        var barberSchedule = new BarberSchedule
        {
            BarberId = barberId,                     
            CurrentYear = DateTime.UtcNow.Year,     
            LastModifiedDate = DateTime.UtcNow,      
            AvailabilitySlots = availabilitySlots    
        };

        return barberSchedule;
    }
}

