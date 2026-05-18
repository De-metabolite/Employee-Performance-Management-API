namespace Employee_Performance_Management_API.Models
{
    public class Department:BaseEntity
    {
       
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public ICollection<Employee>? Employees {  get; set; }
      
    }
}
