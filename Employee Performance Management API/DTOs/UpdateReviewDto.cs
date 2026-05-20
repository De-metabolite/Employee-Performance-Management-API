using System.ComponentModel.DataAnnotations;
using Employee_Performance_Management_API.Models;
namespace Employee_Performance_Management_API.DTOs
{
    public record UpdateRewiewDto
        (
         [Required]
         string? Id,
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
             DateTime UpdatedOn,
         [Required]
             [StringLength(50)]
             string? UpdatedBy
      );
}
