using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Please, enter the email")]
    // [EmailAddress(ErrorMessage = "You've entered an invalid email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please, enter the password")]
    [DataType(DataType.Password)]
    [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 15 characters")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}