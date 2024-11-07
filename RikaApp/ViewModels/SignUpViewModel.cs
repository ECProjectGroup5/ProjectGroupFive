using System.ComponentModel.DataAnnotations;

namespace RikaApp.ViewModels;

/// <summary>
/// 
/// </summary>
public class SignUpViewModel
{
	public string Email { get; set; } = null!;

	public string Password { get; set; } = null!;

	public bool TermsAndConditions { get; set; }
}