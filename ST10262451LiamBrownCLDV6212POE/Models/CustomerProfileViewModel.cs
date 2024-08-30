using System.ComponentModel.DataAnnotations;

public class CustomerProfileViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // Additional fields as needed
}
