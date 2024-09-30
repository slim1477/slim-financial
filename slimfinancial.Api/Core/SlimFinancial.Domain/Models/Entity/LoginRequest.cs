namespace SlimFinancial.Domain.Models.Entity;

// Represents login request
public class LoginRequest{
    public string Username {get;set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
}