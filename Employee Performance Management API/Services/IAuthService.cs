using Employee_Performance_Management_API.DTOs;

namespace Employee_Performance_Management_API.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto> LoginResponseDtoAsync(LoginDto dto);
    }

}
