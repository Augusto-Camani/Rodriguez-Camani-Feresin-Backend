namespace Rodriguez_Camani_Feresin_Backend.DTO
{
    public class ClientDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
    }
}