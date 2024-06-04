namespace Rodriguez_Camani_Feresin_Backend;

public interface IValidationService
{
    public bool ValidateEmail(string email);
    public bool ValidatePassword(string password);
}
