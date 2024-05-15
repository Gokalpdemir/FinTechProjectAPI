using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Abstractions.Services
{
    public interface IInternalAuthenticationService
    {
        Task<bool> loginAsync(string userNameOrEmail, string password);
    }
}
