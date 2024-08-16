namespace Studentportal.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;  // Default value to avoid null issues
        public string Password { get; set; } = string.Empty;  // Default value to avoid null issues

        // Parameterized constructor to ensure required properties are set
        public LoginViewModel(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        // Parameterless constructor for use with frameworks like MVC
        public LoginViewModel() { }
    }
}
