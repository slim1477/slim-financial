

namespace SlimFinancial.Domain.Dtos;

    public class PersonDto
    {
    public string PersonNumber { get; set; } = string.Empty;
    public string Fname { get; set; } = string.Empty ;
    public string Lname {  get; set; } = string.Empty ;
    public DateOnly DateOfBirth { get; set; } = default;
    public string Address { get; set; } = string .Empty ;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    }

