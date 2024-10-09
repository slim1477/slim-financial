using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models.Entity;


namespace SlimFinancial.Application.IService;

// represents basic authentication service
public interface IAuthService
{
    Task<LoginResponse> Login(LoginRequestDto req);
    Task<LoginResponse> Register(RegisterRequestDto req);
    void Logout();
}
