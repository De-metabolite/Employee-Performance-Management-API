using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
namespace Employee_Performance_Management_API.DTOs
{
    public record RegisterDto(
        [Required]
        [StringLength(50,ErrorMessage ="Maximum name character reached")]
        string FirstName,
        [Required]
        [StringLength(50,ErrorMessage ="Maximum name character reached")]
        string LastName,
        [Required]
        string DepartmentalId,
        [Required]
        decimal Salary,

       [Required]
       [EmailAddress]
        string Email,
       [Required]
        string Password,
       [Required]
       [DataType(DataType.Date)]
       DateTime HiredDate,
       [Required]
       [Phone]
       string PhoneNumber



   );
    
}
