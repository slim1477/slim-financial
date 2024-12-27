using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;


namespace SlimFinancial.Application.Service;

// represents basic authentication service
public interface IPersonService
{
    Task<PersonLoginResponseDto> Login(PersonLoginRequestDto req);
    Task<PersonRegisterResponseDto> Register(PersonRegisterRequestDto req);
    Task<IEnumerable<PersonDto>> GetAll();
    Task<PersonDto> GetByPersonNumber(string id);
    void Logout();
}
