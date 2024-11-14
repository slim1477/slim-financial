using SlimFinancial.Domain.Models;


namespace SlimFinancial.Domain.Dtos;

    public class DebitCardDto
    {
    public string PersonId { get; set; } = default!;
    public string Pan { get; set; } = string.Empty;
    public DateOnly DateCreated { get; set; }
    public bool IsActive { get; set; }
    public List<Account> Accounts { get; set; } = [];
    }

