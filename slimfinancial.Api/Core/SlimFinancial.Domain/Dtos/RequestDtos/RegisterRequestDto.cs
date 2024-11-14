

namespace SlimFinancial.Domain.Dtos;

    /// <summary>
    /// Represents a data transfer object for registration request
    /// </summary>
    public class RegisterRequestDto
    {
    public string Fname { get; set; } = string.Empty;
    public string Lname { get; set; } = string.Empty;
    public string Email {  get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword {  get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

