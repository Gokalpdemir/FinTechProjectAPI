using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string NameSurname { get; set; }
       
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}



