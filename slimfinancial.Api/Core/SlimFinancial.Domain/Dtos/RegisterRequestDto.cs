

namespace SlimFinancial.Domain.Dtos;

    public class RegisterRequestDto
    {
    public string Fname { get; set; } = string.Empty;
    public string Lname { get; set; } = string.Empty;
    public string Email {  get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

