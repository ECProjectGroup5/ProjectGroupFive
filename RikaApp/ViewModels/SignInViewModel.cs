using System.ComponentModel.DataAnnotations;

namespace RikaApp.ViewModels;

public class SignInViewModel
{
    [Required(ErrorMessage = "A valid email is required")]
    [Display(Name = "Email Address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Display(Name = "Remember me", Prompt = "Remember me")]
    public bool RememberMe { get; set; }
}
