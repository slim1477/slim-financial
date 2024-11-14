

namespace SlimFinancial.Domain.Dtos.ResponseDtos;

    /// <summary>
    /// Represents a response for a request to create a new transaction
    /// </summary>
    public class TransactionResDto
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }

