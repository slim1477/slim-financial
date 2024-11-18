using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;


namespace SlimFinancial.Application.Service;

// represents basic authentication service
public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequestDto req);
    Task<RegisterResponseDto> Register(RegisterRequestDto req);
    Task<IEnumerable<PersonDto>> GetAll();
    void Logout();
}
