
namespace SlimFinancial.Domain.Dtos;

/// <summary>
/// Represents the data transfer object for an Account
/// </summary>
    public class AccountDto
    {
    public string PersonNumber { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Status {  get; set; } = string.Empty;

    public double Balance { get; set; }
    }

