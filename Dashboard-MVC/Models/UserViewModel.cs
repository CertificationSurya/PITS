using System.ComponentModel.DataAnnotations;

public class UserViewModel
{
    public string? Uuid { get; set; }

    [Required(ErrorMessage = "namm lekhega ya dauda dauda kei maruuuu!")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "email lekhega ya dauda dauda kei maruuuu!")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; }

    [Required(ErrorMessage = "role select karega ya dauda dauda kei maruuuu!")]
    [RegularExpression("^(Student|Admin|Teacher)$",
        ErrorMessage = "Invalid role selected")]
    public string Role { get; set; }
}


