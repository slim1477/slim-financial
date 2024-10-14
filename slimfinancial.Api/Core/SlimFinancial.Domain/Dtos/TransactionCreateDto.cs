

namespace SlimFinancial.Domain.Dtos;

    public class TransactionCreateDto
    {
       public string SourceId { get; set; } = string.Empty;
        public string DestinationId { get; set; } = string.Empty ;
        public double TransactionAmount { get; set; }   

    }

