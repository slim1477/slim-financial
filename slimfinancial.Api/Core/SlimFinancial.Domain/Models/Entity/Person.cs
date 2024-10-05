
using Microsoft.AspNetCore.Identity;


namespace SlimFinancial.Domain.Models.Entity;

// Represents a person
public class Person : IdentityUser{
    public string Fname {get;set;} = string.Empty;
    public string Lname {get;set;} = string.Empty;
    public DateOnly DateOfBirth {get;set;}
    public string Address {get;set;} = string.Empty;

    public List<Account> Accounts { get; set; } = [];
    
}