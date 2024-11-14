

namespace SlimFinancial.Domain.Models;

/// <summary>
/// Represents the account debit card many-to-many relationship
/// </summary>
    public class AccountDebitCard
    {
        public int Pan { get; set; } 
        public int AccountNumber { get; set; } 
        public DebitCard DebitCard { get; set; } = default!;
        public Account Account { get; set; } = default!;
    }

