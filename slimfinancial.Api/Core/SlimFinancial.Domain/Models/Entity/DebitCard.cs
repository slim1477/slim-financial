

namespace SlimFinancial.Domain.Models.Entity;

    public class DebitCard
    {
    public string Id { get; set; } = string.Empty;
    public Person OwnerId { get; set; } 
    public string Pan {  get; set; } = string.Empty;
    public List<Account> LinkedAccounts { get; set; } = [];
    }

