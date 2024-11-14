

namespace SlimFinancial.Domain.Dtos;

    // Represents a data transfer object for non-generic responses
    public class ReqResponseDto
    {
      public bool Success { get; set; }
      public string Message { get; set; } = string.Empty;
    }

