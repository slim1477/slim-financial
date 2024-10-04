using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SlimFinancial.Application;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models.Entity;
using SlimFinancial.Infrastructure.Helper;



namespace SlimFinancial.Infrastructure.Services;
// Represent authentication services
public class AuthService(UserManager<IdentityUser> userManager,IOptions<JwtConfig> jwt) : IAuthService
{
    private readonly UserManager<IdentityUser>  _userManager = userManager;
    private readonly IOptions<JwtConfig> _jwtConfig = jwt;
    public async Task<LoginResponse> Login(LoginRequestDto req)
    {
        throw new NotImplementedException();
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }

    public async Task<LoginResponse> Register(LoginRequestDto payload)
    {
        var usernameExist = await _userManager.FindByEmailAsync(payload.Username);
        if (usernameExist != null) return new LoginResponse
        {
            SessionToken = string.Empty,
            Status = false,
            Message = "Email already exist"
        };
        var newUser = new IdentityUser()
        {
            UserName = payload.Username,
            Email = "t@test.com"
        };
        var isCreated = _userManager.CreateAsync(newUser, payload.Password);
        if (isCreated.IsCompletedSuccessfully)
        {
            try
            {
                return new LoginResponse
                {
                    SessionToken = JwtHelper.GenerateJwtToken(newUser, _jwtConfig),
                    Status = true,
                    Message = "Created"
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    SessionToken = "",
                    Status = false,
                    Message = ex.Message
                };
            }
        }
        return new LoginResponse
        {
            SessionToken = String.Empty,
            Status = false,
            Message = "there was an error, please try again"
        };


    }
}

