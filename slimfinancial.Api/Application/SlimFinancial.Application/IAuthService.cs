using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models.Entity;


namespace SlimFinancial.Application;

    // represents basic authentication service
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequestDto req);
        Task<LoginResponse> Register(LoginRequestDto req);
        void Logout();
    }
