

namespace SlimFinancial.Domain.Dtos;

    public class TransactionDto
    {
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty ;
    public string Type { get; set; } = string.Empty;
    public double Amount { get; set; }
    public string AccountNumber { get; set; } = string.Empty;

    }

