

namespace SlimFinancial.Domain.Models.Entity;

/// <summary>
/// Represents a debit card
/// </summary>
    public class DebitCard
    {
    public string Id { get; set; } = string.Empty;
    public required string PersonId { get; set; } 
    public string Pan {  get; set; } = string.Empty;
    public List<Account> LinkedAccounts { get; set; } = [];
    }

