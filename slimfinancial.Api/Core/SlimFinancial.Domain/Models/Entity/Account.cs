using SlimFinancial.Domain.Models.Common.Enums;

namespace SlimFinancial.Domain.Models.Entity;

//Represents an Account
public class Account{
    public string Id {get; set;} = string.Empty;

    public string AccountNumber {get; set;} = string.Empty;

    public AccountType Type {get; set;}

    public int Balance {get; set;}

    public List<Person> JointOwners { get; } = [];

}