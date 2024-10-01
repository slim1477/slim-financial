

namespace SlimFinancial.Domain.Models.Entity;

    // Represents a login request Response
    public class LoginResponse
    {
    public string SessionToken { get; set; } = string.Empty;
    public bool Status { get; set; }
    public List<string>? Message { get; set; } 
    }
