using Employee_Performance_Management_API.Data;
using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Employee_Performance_Management_API.Controllers
{
    [Route("api/performancereviews")]
    [ApiController]
    public class PerformanceReviewsController : ControllerBase
    {
        private readonly IPerformanceReviewService _performanceReviewService;
        public PerformanceReviewsController(IPerformanceReviewService performanceReviewService)
        {

            _performanceReviewService = performanceReviewService;
        }
      
        [HttpGet("GetMyReviews")]
        [Authorize]
        public async Task<IActionResult> GetMyReviewsAsync()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _performanceReviewService.GetMyReviewsAsync(userid);
            return Ok(result);

        }
        
        
        [HttpGet("GetAllReviews")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllReviews()
        {
            var result = await _performanceReviewService.GetAllReviews();
            return Ok(result);
        }
        
        [HttpGet("GetEmployeeReviewsById")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> GetEmployeeReviewsByIdAsync(string EmployeeId)
        {
            var result = await _performanceReviewService.GetEmployeeReviewsByIdAsync(EmployeeId);
            return Ok(result);
        }

        [HttpPost("CreateReview")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> CreateReviewAsync(CreateReviewDto dto)
        {
            await _performanceReviewService.CreateReviewAsync(dto);
            return Ok("Review Created Successfully");
        }
        
        [HttpPut("UpdateRewiew")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> UpdateRewiewAsync(UpdateRewiewDto dto)
        {
            await _performanceReviewService.UpdateRewiewAsync(dto);
            return Ok("Review updated");

        }
       
        [HttpPost("SelfAssessment")]
        [Authorize]
        public async Task<IActionResult> SelfAssessmentAsync( CreateReviewDto dto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _performanceReviewService.SelfAssessmentAsync(userid,dto);
            return Ok("You have successfully assessed yourself.");

        }
       
        [HttpDelete("DeleteReviewById")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> DeleteReviewAsync(string RevieweeId)
        {
            await _performanceReviewService.DeleteReviewAsync(RevieweeId);
            return Ok("Review deleted successfully");
        }
    }
}
