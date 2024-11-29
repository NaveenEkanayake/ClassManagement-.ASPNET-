namespace Studentportal.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;  
        public string Password { get; set; } = string.Empty;  
        public LoginViewModel(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
        public LoginViewModel() { }
    }
}
