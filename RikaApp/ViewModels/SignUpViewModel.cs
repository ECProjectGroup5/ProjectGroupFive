using System.ComponentModel.DataAnnotations;

namespace RikaApp.ViewModels;

/// <summary>
/// The model for user signing up, capturing needed information such as username, email, password, and agreeing to terms and conditions.
/// </summary>
public class SignUpViewModel
{
    [Required]
    [Display(Name = "User", Prompt = "Enter your user name")]
    public string User { get; set; } = null!;

    [Required]
    [Display(Name = "Email Address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Confirm Password", Prompt = "Confirm your password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = "You must agree to the terms and conditions.")]
    [Display(Name = "I agree to the terms and conditions")]
    public bool TermsAndConditions { get; set; }
}
