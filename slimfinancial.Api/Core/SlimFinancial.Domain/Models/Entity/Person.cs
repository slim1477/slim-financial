
using Microsoft.AspNetCore.Identity;


namespace SlimFinancial.Domain.Models;

// Represents a person
public class Person : IdentityUser<int>{
    public int PersonNumber{ get; set; }
    public string Fname {get;set;} = string.Empty;
    public string Lname {get;set;} = string.Empty;
    public DateOnly DateOfBirth {get;set;}
    public string Address {get;set;} = string.Empty;
    public ICollection<Account> Accounts { get; set; } = [];
    public ICollection<PersonDebitCard> DebitCards { get; set; } = [];
    public ICollection<PersonAccount> JointAccounts { get; set; } = [];


}