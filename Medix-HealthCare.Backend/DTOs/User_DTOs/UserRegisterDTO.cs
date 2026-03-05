namespace HealthcareSystem.DTOs.User_DTOs
{
    public class UserRegisterDTO
    {
        public string UserName {  get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        public string Phone_Number { get; set; }
    }
}
