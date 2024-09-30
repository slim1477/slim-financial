using SlimFinancial.Domain.Models.Entity;


namespace SlimFinancial.API.Application;

    // represents basic authentication service
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest req);
        void Logout();
    }
