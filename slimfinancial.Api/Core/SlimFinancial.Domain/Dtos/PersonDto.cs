

namespace SlimFinancial.Domain.Dtos;

    public class PersonDto
    {
    public string Id { get; set; } = string.Empty;
    public string Fname { get; set; } = string.Empty ;
    public string Lname {  get; set; } = string.Empty ;
    public DateOnly DateOfBirth { get; set; } = new DateOnly() ;
    public string Address { get; set; } = string .Empty ;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    }

