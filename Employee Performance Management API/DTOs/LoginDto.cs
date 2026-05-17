using System.ComponentModel.DataAnnotations;

namespace Employee_Performance_Management_API.DTOs
{
    public record LoginDto(
        [Required] 
        string Email, 
        [Required]
        string Password);

}
