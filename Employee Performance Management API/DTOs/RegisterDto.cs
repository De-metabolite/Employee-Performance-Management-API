using System.ComponentModel.DataAnnotations;
namespace Employee_Performance_Management_API.DTOs
{
    public record RegisterDto(
        [Required] 
        [StringLength(50,ErrorMessage ="Maximum name character reached")]
        string FullName,

       [Required] 
       [EmailAddress]
        string Email,
       [Required]
        string Password,
       [Required]
       [Phone]
       string PhoneNumber


        );
    
}
