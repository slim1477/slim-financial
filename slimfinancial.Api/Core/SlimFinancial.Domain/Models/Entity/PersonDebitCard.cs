

namespace SlimFinancial.Domain.Models;


/// <summary>
/// Represents the person-debit card many-to-many-relationship
/// </summary>
    public class PersonDebitCard
    {
    public int PersonNumber { get; set; }
    public int Pan { get; set; } 
    public Person Person { get; set; } = default!;
    public DebitCard DebitCard { get; set; } = default!;
    }

