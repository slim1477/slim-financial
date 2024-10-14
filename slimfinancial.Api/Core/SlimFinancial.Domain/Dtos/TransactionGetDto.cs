

namespace SlimFinancial.Domain.Dtos;

    public class TransactionGetDto
    {
    public string Id { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty ;
    public double Amount { get; set; }
    public DateOnly Date {  get; set; }
    public string SourceAccountId { get; set; } = string.Empty;

    }

