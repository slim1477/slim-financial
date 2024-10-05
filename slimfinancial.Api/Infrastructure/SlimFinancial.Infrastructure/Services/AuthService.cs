using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SlimFinancial.Application.IService;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models.Entity;
using SlimFinancial.Infrastructure.Data;
using SlimFinancial.Infrastructure.Helper;


namespace SlimFinancial.Infrastructure.Services;
// Represent authentication services
public class AuthService(UserManager<Person> userManager, IOptions<JwtConfig> jwt,AppDbContext dbContext) : IAuthService
{
    private readonly UserManager<Person>  _userManager = userManager;
    private readonly IOptions<JwtConfig> _jwtConfig = jwt;
    private readonly AppDbContext _dbContext = dbContext;


    /// <summary>
    /// checks if username submitted is a debit card number or username
    /// </summary>
    /// <param name="req"></param>
    /// <returns>a registered user</returns>
    private Task<Person?> _GetUsernameType(LoginRequestDto req)
    {
        var isPan = Int32.TryParse(req.Username, out int result);

        if (isPan)
        {
            var debitCard = _dbContext.DebitCards.Where(x => x.Pan == req.Username).First();
            var userId = debitCard.PersonId;
            var userByPan =  _userManager.FindByIdAsync(userId);
            return userByPan;

        }
         var userByUsername = _userManager.FindByNameAsync(req.Username);
        return userByUsername;

    }

    /// <summary>
    /// Handles login request
    /// </summary>
    /// <param name="req"></param>
    /// <returns>a valid token if user is authenticated</returns>
    public async Task<LoginResponse> Login(LoginRequestDto req)
    {
        var userExists = _GetUsernameType(req).Result;
        if (userExists == null) return new LoginResponse
        {
            SessionToken = "",
            Status = false,
            Message = "not found"
        };
        
        var authUser = await _userManager.CheckPasswordAsync(userExists, req.Password);
        if (!authUser) return new LoginResponse
        {
            SessionToken = "",
            Status = false,
            Message = "not authorized"
        };
        return new LoginResponse
        {
            SessionToken = JwtHelper.GenerateJwtToken(userExists, _jwtConfig),
            Status = true,
            Message = "success"
        };
    }


    /// <summary>
    /// Handles logout request
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Logout()
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Handles new user reqistration request
    /// </summary>
    /// <param name="payload"></param>
    /// <returns>a registered user</returns>
    public async Task<LoginResponse> Register(RegisterRequestDto payload)
    {
        var usernameExist = await _userManager.FindByEmailAsync(payload.Email);
        try
        {   
            if (usernameExist != null) return new LoginResponse
            {
                SessionToken = string.Empty,
                Status = false,
                Message = "Email already exist"
            };
            var newUser = new Person()
            {
                
                Email = payload.Email,
            };
            var isCreated = await _userManager.CreateAsync(newUser, payload.Password);
            if (isCreated.Succeeded)
            {
                return new LoginResponse
                {
                    SessionToken = JwtHelper.GenerateJwtToken(newUser, _jwtConfig),
                    Status = true,
                    Message = "Created"
                };
            }
        }catch (Exception ex)
            {
                return new LoginResponse
                       {
                           SessionToken = "",
                           Status = false,
                           Message = ex.Message
                        };
            }

        return new LoginResponse
        {
            SessionToken = String.Empty,
            Status = false,
            Message = "there was an error, please try again"
        };
    }

    public void Update(Person entity)
    {
        throw new NotImplementedException();
    }
}
        
