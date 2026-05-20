using Employee_Performance_Management_API.Data;
using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Employee_Performance_Management_API.Services
{
    public class PerformanceReviewService : IPerformanceReviewService
    {
       
        private readonly ApplicationDbContext _context;
        public PerformanceReviewService( ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<PerformanceReview>> GetMyReviewsAsync(string userid)
        {
            var employee = await _context.Employees.Include(u => u.Reviews).FirstOrDefaultAsync(u => u.IdentityUserId == userid);
            if (employee == null)
            {
                throw new Exception("Invalid User Review");
            }
            return employee.Reviews;
        }
        public async Task<IEnumerable<PerformanceReview>> GetAllReviews()
        {
            return await _context.PerformanceReviews.ToListAsync();
        }
       public async Task<IEnumerable<PerformanceReview>> GetEmployeeReviewsByIdAsync(string EmployeeId)
        {
            var employee = await _context.Employees.Include(u => u.Reviews).FirstOrDefaultAsync(u => u.Id == EmployeeId);
            if (employee == null)
            {
                throw new Exception("Invalid User Review");
            }
            return employee.Reviews;
        }
        public async Task<bool> CreateReviewAsync(CreateReviewDto dto)
        {
            var review = new PerformanceReview
            {
                Score = dto.Score,
                Comments = dto.Comments,
                Goals = dto.Goals,
                status = dto.status,
                EmployeeId = dto.EmployeeId,
                CreatedOn = dto.CreatedOn,
                CreatedBy = dto.CreatedBy

            };
            _context.PerformanceReviews.Add(review);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateRewiewAsync(UpdateRewiewDto dto)
        {
            var review = await _context.PerformanceReviews.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (review == null)
            {
                throw new Exception("No review found.");
            }
            var newupdate = new PerformanceReview
            {
                Id = dto.Id,
                Score = dto.Score,
                Comments = dto.Comments,
                status = dto.status,
                EmployeeId = dto.EmployeeId,
                ModifiedBy = dto.UpdatedBy,
                ModifiedOn = dto.UpdatedOn,


            };
            _context.PerformanceReviews.Update(newupdate);
            await _context.SaveChangesAsync();
            return true;
        }
         public async Task<bool> SelfAssessmentAsync(string userid, CreateReviewDto dto)
        {
            var employee = _context.Employees.FirstOrDefault(u => u.IdentityUserId == userid);

            var newreview = new PerformanceReview
            {
                EmployeeId = employee.Id,
                status = dto.status,
                Comments = dto.Comments,
                CreatedBy = dto.CreatedBy,
                CreatedOn = dto.CreatedOn,
                Goals = dto.Goals,
            };
            _context.PerformanceReviews.Add(newreview);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> DeleteReviewAsync(string RevieweeId)
        {
            var review = await _context.PerformanceReviews.FirstOrDefaultAsync(u => u.Id == RevieweeId);
            if (review == null)
            {
                throw new Exception("This review doesn't exist!.");
            }
            _context.PerformanceReviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;



        }
    }
}
