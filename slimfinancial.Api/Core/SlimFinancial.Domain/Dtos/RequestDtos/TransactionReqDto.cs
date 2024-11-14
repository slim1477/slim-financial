

using SlimFinancial.Domain.Models.Common;

namespace SlimFinancial.Domain.Dtos;

    
    public class TransactionReqDto
    {
        public string SourceAcctNumber { get; set; } = string.Empty;
        public string DestinationAccountNumber { get; set; } = string.Empty ;
        public double TransactionAmount { get; set; }
        public string Description { get; set; } = string.Empty;

    }

