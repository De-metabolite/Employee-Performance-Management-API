using Employee_Performance_Management_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Employee_Performance_Management_API.Models;
using Employee_Performance_Management_API.Services;
using Employee_Performance_Management_API.DTOs;


namespace Employee_Performance_Management_API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeService _employeeservice;
        public EmployeesController(ApplicationDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeservice = employeeService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyProfile()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var employee = await _context.Employees.FirstOrDefaultAsync(u => u.IdentityUserId == userid);
            if (employee == null)
            {
                throw new Exception("Your details can't be fetched ");
            }
            return Ok(employee);
        }
        [HttpGet("GetAllEmployees")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeservice.GetAllEmployeesAsync();
            return Ok(result);
        }
        [HttpGet("GetEmployeeById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployeeById(string EmployeeId)
        {
            var result = await _employeeservice.GetEmployeeById(EmployeeId);
            return Ok(result);

        }
        [HttpPut("UpdateEmployeeById")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> UpdateEmployeeById(string Id, EmployeeDto dto)
        {
            await _employeeservice.UpdateEmployeeByIdAsync(Id, dto);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteEmployeeById")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteEmployeeById(string Id)
        {
            await _employeeservice.DeleteEmployeeByIdAsync(Id);
            return Ok("Employee records deleted successfully");
        }
    }
}
