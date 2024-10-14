

using AutoMapper;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;
/// <summary>
/// REpresents the automapper configuration
/// </summary>
    public class AutoMapperConfig : Profile
    {
    public AutoMapperConfig() 
    {
        CreateMap<Account,AccountDto>().ReverseMap();
        CreateMap<Transaction,TransactionGetDto>().ReverseMap();
        CreateMap<Person,PersonDto>().ReverseMap();
    }
    }

