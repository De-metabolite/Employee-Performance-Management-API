using Microsoft.AspNetCore.Identity;
namespace Employee_Performance_Management_API.Models
{
    public class AppUser:IdentityUser
    {
        public string? FullName { get; set;  }
        public Employee? Employee { get; set; }

    }
}
