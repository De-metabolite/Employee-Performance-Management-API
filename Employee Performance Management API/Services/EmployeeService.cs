using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Models;
using Employee_Performance_Management_API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Employee_Performance_Management_API.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public EmployeeService( ApplicationDbContext context, UserManager<AppUser> userManager ) 
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(string Id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u=>u.Id == Id);
            if(employee == null)
            {
                throw new Exception("Not result");
            }
            return employee;
        }
        public async Task<bool> UpdateEmployeeByIdAsync(string EmployeeId, EmployeeDto dto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u=>u.Id == EmployeeId);
            if(employee != null)
            {
                var newupdate = new Employee
                {
                    Id = EmployeeId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Position = dto.Position,
                    HiredDate = dto.HiredDate,
                    ModifiedBy = dto.ModifiedBy,
                };
                _context.Employees.Add(newupdate);
                await _context.SaveChangesAsync();
            }
            return true;

        }
        public async Task<bool> DeleteEmployeeByIdAsync(string EmployeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u => u.Id == EmployeeId);
            if (employee == null)
            {
                throw new Exception("No employee with the Id.");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
