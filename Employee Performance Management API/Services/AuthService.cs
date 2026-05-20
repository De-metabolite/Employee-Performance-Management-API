using Employee_Performance_Management_API.Data;
using Employee_Performance_Management_API.DTOs;
using Employee_Performance_Management_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
namespace Employee_Performance_Management_API.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtsettings;
        private readonly ApplicationDbContext _context;
        public AuthService(UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings, ApplicationDbContext context)
        {
            _jwtsettings = jwtSettings.Value;
            _userManager = userManager;
            _context = context;
        }
        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new AppUser
            {   
                FirstName= dto.FirstName,
                LastName= dto.LastName,
                Email = dto.Email,
                UserName= dto.Email,
                PhoneNumber = dto.PhoneNumber,


            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var error = result.Errors.Select(e => e.Description).ToString();
                throw new Exception(error);
               
            }
            var roleassigned= await _userManager.AddToRoleAsync(user, "Employee");
            if (!roleassigned.Succeeded) 
            {
                var error = roleassigned.Errors.Select(e => e.Description).ToString();
                throw new Exception(error);
            }

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdentityUserId = user.Id,
                DepartmentId = dto.DepartmentalId,
                HiredDate = dto.HiredDate,
                Salary= dto.Salary,


            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

           
        }
        public async Task<LoginResponseDto> LoginResponseDtoAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("Invalid Email/password.");
            }
            var validpassword = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!validpassword)
            {
                throw new Exception("Invalid Email/Password.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var Token = GenerateToken(user, roles);
            var Roles = roles.FirstOrDefault() ?? "Employee";
            var ExpiresAt = DateTime.UtcNow.AddHours(_jwtsettings.ExpiresInHours);
            
            return new LoginResponseDto(Token, Roles, ExpiresAt);

        }
        public string GenerateToken(AppUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault() ?? "Employee"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //Building the Token
            var token = new JwtSecurityToken(
                issuer: _jwtsettings.Issuer,
                audience: _jwtsettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtsettings.ExpiresInHours),
                signingCredentials: credentials
                );

            // serialize to string and return the value
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }   
}
