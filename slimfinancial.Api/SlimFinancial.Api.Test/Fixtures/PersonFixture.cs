

using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.UnitTest.Fixtures;

    public class PersonFixture
    {
       public static PersonLoginRequestDto GetLoginRequest()
        {
        return new PersonLoginRequestDto
        {
            Username = "testUser",
            Password = "password",
        };
        }
    }

