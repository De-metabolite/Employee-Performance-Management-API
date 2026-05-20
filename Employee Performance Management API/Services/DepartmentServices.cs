using Employee_Performance_Management_API.Data;
using Employee_Performance_Management_API.Models;
using Employee_Performance_Management_API.DTOs;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Performance_Management_API.Services
{
    public class DepartmentServices:IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public DepartmentServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string departmentId)
        {
            var department = await _context.Employees.Where(u=>u.DepartmentId == departmentId).ToListAsync();
            return department;
        }
        public async Task<bool> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            var departments = new Department
            {
                Name= dto.Name,
                Description= dto.Description,
                Salary = dto.Salary,
            };
            
                _context.Departments.Add(departments);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateDepartmentByIdAsync(string departmentId,CreateDepartmentDto dto)
        {
            var department =  await _context.Departments.FirstOrDefaultAsync(u => u.Id == departmentId);
            if (department == null)
            {
                throw new Exception("Department not found");
            }

            var newupdate = new Department
            {
                Id = departmentId,
                Name = dto.Name,
                Description = dto.Description,
                Salary = dto.Salary,
            };
            _context.Departments.Update(newupdate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDepartmentByIdAsync(string departmentId)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(u => u.Id == departmentId);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
             _context.Departments.Remove(department);
             await _context.SaveChangesAsync();
            return true;
        }
    }
}
