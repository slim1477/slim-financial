

namespace SlimFinancial.Domain.Models;

    // Represents a login request Response
    public class LoginResponse
    {
    public string SessionToken { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Message { get; set; } = string.Empty;
    }
