using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Models;

namespace Employee_Performance_Management_API.Services
{
    public interface IEmployeeService
    {
      
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeById(string Id);
        Task<bool> UpdateEmployeeByIdAsync(string EmployeeId, EmployeeDto dto);
        Task<bool> DeleteEmployeeByIdAsync(string departmentId);
    }
}
