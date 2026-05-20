using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Employee_Performance_Management_API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentsController(IDepartmentService departmentservice)
        {
            _departmentservice = departmentservice;
        }
        [HttpGet("GetAllDepartments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDepartments() 
        {
           var result= await _departmentservice.GetAllDepartmentAsync();

          return Ok(result);
        }
        [HttpPost("CreateDepartment")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto dto)
        {
            await _departmentservice.CreateDepartmentAsync(dto);
            return Ok("The department has been created successfully");
        }
        [HttpGet("GetEmployeesbyDepartment")]
         [Authorize(Roles ="HR,Manager")]
        public async Task<IActionResult> GetEmployeesByDepartmentAsync(string departmentId)
        {
            var result = await _departmentservice.GetEmployeesByDepartmentAsync(departmentId);
            return Ok(result);
        }
        [HttpPut("UpdateDepartment")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> UpdateDepartmentByIdAsync(string departmentId, CreateDepartmentDto dto)
        {
            await _departmentservice.UpdateDepartmentByIdAsync(departmentId, dto);
            return Ok("Department updated successfully.");
        }

        [HttpDelete("DeleteDepartment")]
        [Authorize(Roles ="HR")]
        public async Task<IActionResult> DeleteDepartmentByIdAsync(string departmentId)
        {
            await _departmentservice.DeleteDepartmentByIdAsync(departmentId);
            return Ok("Department deleted successfully.");
        }
    }
}

