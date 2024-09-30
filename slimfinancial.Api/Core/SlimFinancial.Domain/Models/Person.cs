namespace Slimfinancial.Api.Models;

// Represents a person
public class Person{
    public int Id {get;set;}
    public string Fname {get;set;} = string.Empty;
    public string Lname {get;set;} = string.Empty;
    public DateOnly DateOfBirth {get;set;}
    public string Email {get;set;} = string.Empty;
    public string PhoneNumber {get; set;} = string.Empty;
    public string Address {get;set;} = string.Empty;
}