using Employee_Performance_Management_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Performance_Management_API.DTOs
{
    public record CreateReviewDto(
            [Required]
            int Score,
            [Required]
            string? Comments,
            [Required]
            string? Goals,
            [Required]
            [EnumDataType(typeof(Status))]
            Status status,
            [Required]
            string? EmployeeId,
            [Required]
            [DataType(DataType.Date)]
            DateTime CreatedOn,
            [Required]
            [StringLength(50)]
            string? CreatedBy
         );
   
    
   
}
