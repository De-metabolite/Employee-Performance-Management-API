using Employee_Performance_Management_API.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Performance_Management_API.DTOs
{
    public record EmployeeDto
    (
        [Required]
        string? Id,
        [Required]
        [StringLength(50)]
        string? FirstName,
        [Required]
        [StringLength(50)]
         string? LastName,
        [Required]
        [StringLength(50)]
        string? ModifiedBy,
        [Required]
        [StringLength(50)]
        string? Position,
        decimal? Salary,
        [Required]
        [DataType(DataType.Date)]
        DateTime? HiredDate
    );
}
