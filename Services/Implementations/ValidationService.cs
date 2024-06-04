using System.Text.RegularExpressions;

namespace Rodriguez_Camani_Feresin_Backend;

public class ValidationService : IValidationService
{
    public bool ValidateEmail(string email)
    {
       if(string.IsNullOrEmpty(email)) return false;

        var trimmedEmail = email.Trim();
       try
       {
        var address = new System.Net.Mail.MailAddress(trimmedEmail);
        return address.Address == trimmedEmail;
       } 
       catch
       {
        return false;
       }
    }

    public bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        
        var regex = new Regex("^(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d]{8,16}$");
        return regex.IsMatch(password);
    }
}
