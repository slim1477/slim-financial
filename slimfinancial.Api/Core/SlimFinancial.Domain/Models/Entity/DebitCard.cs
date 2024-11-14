

namespace SlimFinancial.Domain.Models;

    /// <summary>
    /// Represents a debit card
    /// </summary>
    public class DebitCard
    {
        public int Pan { get; set; } 
        public int PersonNumber {  get; set; }
        public DateOnly DateCreated { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PersonDebitCard> Persons { get; set; } = [];
        public ICollection<AccountDebitCard> LinkedAccounts { get; set; } = [];
    }

