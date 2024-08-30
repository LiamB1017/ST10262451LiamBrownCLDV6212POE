using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class ImageUploadViewModel
{
    [Required]
    public IFormFile ImageFile { get; set; }
}
