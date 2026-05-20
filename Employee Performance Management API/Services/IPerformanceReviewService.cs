using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Models;

namespace Employee_Performance_Management_API.Services
{
    public interface IPerformanceReviewService
    {
        Task<IEnumerable<PerformanceReview>> GetMyReviewsAsync(string userid);
        Task<IEnumerable<PerformanceReview>> GetAllReviews();
        Task<IEnumerable<PerformanceReview>> GetEmployeeReviewsByIdAsync(string EmployeeId);
        Task<bool> CreateReviewAsync(CreateReviewDto dto);
        Task<bool> UpdateRewiewAsync(UpdateRewiewDto dto);
        Task<bool> SelfAssessmentAsync(string Userid, CreateReviewDto dto);
        Task<bool> DeleteReviewAsync(string RevieweeId);



       

    }
}
