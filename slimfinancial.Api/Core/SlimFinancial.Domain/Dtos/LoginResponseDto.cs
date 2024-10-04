

namespace SlimFinancial.Domain.Dtos;

    public class LoginResponseDto
    {
     public string SessionToken { get; set; } = string.Empty;
    public bool Status { get; set; }
    public List<string>Message { get; set; } = [];
    }

