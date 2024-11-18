using SlimFinancial.Domain.Dtos;


namespace SlimFinancial.Api.UnitTest.Fixtures;

    public class AccountFixture
{
    public static AccountOpenReqDto AccountOpenSuccess()
    {
        return new AccountOpenReqDto
        {
            PersonNumber = "1155226",
        };
    }
    public static AccountOpenReqDto AccountOpenFail()
    {
        return new AccountOpenReqDto
        {
            PersonNumber = string.Empty,
        };
    }



}

