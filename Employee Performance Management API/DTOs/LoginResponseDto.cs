namespace Employee_Performance_Management_API.DTOs
{
    public record LoginResponseDto(string Token, string Role, DateTime ExpiresAt);

   
}
