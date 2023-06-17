using System.ComponentModel.DataAnnotations;
namespace EventFinal.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
