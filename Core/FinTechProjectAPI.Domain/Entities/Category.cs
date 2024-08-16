using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Domain.Entities.Common;
using FinTechProjectAPI.Domain.Entities.Identity;
using FinTechProjectAPI.Domain.Enums;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public string AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }
    public CategoryType Type { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    

    public Category()
    {
       Transactions= new HashSet<Transaction>();

    }


}

