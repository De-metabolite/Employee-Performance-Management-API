using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Performance_Management_API.Models
{
    public class Employee:BaseEntity
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public decimal? Salary { get; set; }
        public string? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public  Department? Department { get; set; } 
        public string?IdentityUserId {  get; set; }
        [ForeignKey(nameof(IdentityUserId))]
        public AppUser? User { get; set; }   
    }
}
