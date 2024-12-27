using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using SlimFinancial.Infrastructure.Data;
using SlimFinancial.Infrastructure.Helper;


namespace SlimFinancial.Infrastructure.Services;
// Represent authentication services
public class PersonService(UserManager<Person> userManager, IOptions<JwtConfig> jwt,AppDbContext dbContext,IMapper mapper) : IPersonService
{
    private readonly UserManager<Person>  _userManager = userManager;
    private readonly IOptions<JwtConfig> _jwtConfig = jwt;
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;


    /// <summary>
    /// checks if username submitted is a debit card number or username
    /// </summary>
    /// <param name="req"></param>
    /// <returns>a registered user</returns>
    private Person? GetUsernameType(PersonLoginRequestDto req)
    {
        var isPan = Int32.TryParse(req.Username,out int result);

        if (isPan)
        {
            var debitCard = _dbContext.DebitCards.Where(x => x.Pan == Int32.Parse(req.Username)).First();
            var userId = debitCard.PersonNumber;
            var userByPan =  _userManager.FindByIdAsync(userId.ToString()).Result;
            return userByPan;

        }
         var userByUsername = _userManager.FindByNameAsync(req.Username).Result;
        return userByUsername;

    }

    /// <summary>
    /// Handles login request
    /// </summary>
    /// <param name="req"></param>
    /// <returns>a valid token if user is authenticated</returns>
    public async Task<PersonLoginResponseDto> Login(PersonLoginRequestDto req)
    {
        var userExists = GetUsernameType(req);
        if (userExists == null) return new PersonLoginResponseDto
        {
            SessionToken = "",
            Success = false,
            Message = "not found"
        };
        
        var authUser = await _userManager.CheckPasswordAsync(userExists, req.Password);
        if (!authUser) return new PersonLoginResponseDto
        {
            SessionToken = "",
            Success = false,
            Message = "not authorized"
        };
        return new PersonLoginResponseDto
        {
            SessionToken = AuthenticationHelper.GenerateJwtToken(userExists, _jwtConfig),
            Success = true,
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
    public async Task<PersonRegisterResponseDto> Register(PersonRegisterRequestDto payload)
    {
        var usernameExist = await _userManager.FindByEmailAsync(payload.Email);
        //var lastPersonNumber = await _dbContext.Persons.Select(x => Int32.Parse(x.PersonNumber)).MaxAsync();
        //var l = await _dbContext.Persons.LastAsync();
        
        try
        {
           var newUser = usernameExist != null ? throw new Exception("Email already exist") : 
                new Person{
                                Fname = payload.Fname,
                                Lname = payload.Lname,
                                Address = payload.Address,
                                DateOfBirth = DateOnly.Parse(payload.DateOfBirth),
                                Email = payload.Email,
                                PhoneNumber = payload.PhoneNumber,
                                UserName = payload.Fname.ToCharArray()[0].ToString() + payload.Lname
                           };

            var isCreated = await _userManager.CreateAsync(newUser, payload.Password);
            if (isCreated.Succeeded)
            {
                return new PersonRegisterResponseDto
                {
                    Success = true,
                    Message = "Created",
                    SessionToken = AuthenticationHelper.GenerateJwtToken(newUser,_jwtConfig)
                };
            }
        }catch (Exception ex)
            {
                return new PersonRegisterResponseDto
                       {
                           
                           Success = false,
                           Message = ex.Message
                        };
            }

        return new PersonRegisterResponseDto
        {
            Success = false,
            Message = "there was an error, please try again"
        };
    }

    public void Update(Person entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets all persons
    /// </summary>
    /// <returns>list of person</returns>
    public  async Task<IEnumerable<PersonDto>> GetAll()
    {
        var persons =  await _dbContext.Persons.ToListAsync();
        return  _mapper.Map<IEnumerable<PersonDto>>(persons);
        

    }

    public async Task<PersonDto> GetByPersonNumber(string personNumber)
    {
        var persons = await _dbContext.Persons.FindAsync(Int32.Parse(personNumber));
        return _mapper.Map<PersonDto>(persons);
    }

}
        
