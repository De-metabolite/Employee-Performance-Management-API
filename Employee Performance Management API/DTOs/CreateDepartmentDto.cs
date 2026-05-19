using System.ComponentModel.DataAnnotations;
namespace Employee_Performance_Management_API.DTOs
{
    public record CreateDepartmentDto
        (
          [Required]
          [StringLength(50)]
          string Name,
          [Required]
          [StringLength(255)]
          string Description,
          [Required]
          decimal Salary
        );
    
}
