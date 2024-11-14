using SlimFinancial.Domain.Models.Common;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Domain.Models;

//Represents an Account
public class Account{

    public int AccountNumber { get; set; }
    public int PersonNumber { get; set; } 
    public AccountType Type {get; set;}

    public AccountStatus Status {get; set;}
    public double Balance {get; set;} 
    public ICollection<AccountDebitCard>? DebitCards {get; set;} = [];
    public Person? Person { get; set; } = default!;
    public ICollection<PersonAccount>? JointOwners { get; set; } = [];
    public ICollection<AccountTransaction>? Transactions { get; set; } = [];


}