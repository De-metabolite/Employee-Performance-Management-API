using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Models;

namespace Employee_Performance_Management_API.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string  departmentId);
        Task<bool> CreateDepartmentAsync(CreateDepartmentDto dto);
        Task<bool> UpdateDepartmentByIdAsync(string departmentId, CreateDepartmentDto dto);
        Task<bool> DeleteDepartmentByIdAsync(string departmentId);
    }
}
