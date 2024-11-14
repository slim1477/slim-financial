

namespace SlimFinancial.Domain.Dtos;

    public class LoginResponseDto
    {
        public string SessionToken { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

