using FinTechProjectAPI.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDto createUserDto);
        
    }
}
