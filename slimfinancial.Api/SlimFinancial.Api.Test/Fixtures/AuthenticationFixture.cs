

using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.UnitTest.Fixtures;

    public class AuthenticationFixture
    {
       public static LoginRequestDto GetLoginRequest()
        {
        return new LoginRequestDto
        {
            Username = "testUser",
            Password = "password",
        };
        }
    }

