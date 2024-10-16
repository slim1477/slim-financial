using SlimFinancial.Domain.Models.Common.Enums;

namespace SlimFinancial.Domain.Models;

//Represents an Account
public class Account{
    public string Id {get; set;} = string.Empty;
    public required string OwnerId { get; set;} 

    public string AccountNumber {get; set;} = string.Empty;

    public AccountType Type {get; set;}

    public double Balance {get; set;}

    public List<Person> JointOwners { get; set; } = [];

}