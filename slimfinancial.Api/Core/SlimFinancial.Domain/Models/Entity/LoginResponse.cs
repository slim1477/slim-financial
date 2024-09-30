

using SlimFinancial.Domain.Models.Common.Enums;

namespace SlimFinancial.Domain.Models.Entity;

    public class LoginResponse
    {
    public string SessionToken { get; set; } = string.Empty;
    public RequestStatus Status { get; set; }
    public string Message { get; set; } = string.Empty ;
    }
