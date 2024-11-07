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
	[Display(Name = "Password", Prompt = "Enter your password")]
	[DataType(DataType.Password)]
	[Compare(nameof(Password), ErrorMessage = "Password does not match")]
	public string ConfirmPassword { get; set; } = null!;

	[Display(Name = "By creating an account you have to agree with our terms and conditions", Prompt = "Terms and conditions")]
	public bool TermsAndConditions { get; set; }
}