

using System.ComponentModel.DataAnnotations;

namespace SlimFinancial.Domain.Dtos;

    // Represents a login request data transfer object
  public class LoginRequestDto
{
    [Required]
    public string Username {  get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty ;
}

