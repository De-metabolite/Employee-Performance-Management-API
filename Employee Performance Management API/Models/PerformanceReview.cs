using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Performance_Management_API.Models
{
    public class PerformanceReview:BaseEntity
    {
        public int Score {  get; set; }
        public string? Comments {  get; set; }
        public string? EmployeeId {  get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

    }
}
