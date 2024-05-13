using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.User;
using FinTechProjectAPI.Application.Exceptions;
using FinTechProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (createUserDto.Password != createUserDto.PasswordConfirm)
                throw new PasswordDoNotMatchException();

            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                Email = createUserDto.Email,
                Id = Guid.NewGuid().ToString(),
                UserName = createUserDto.UserName,
                NameSurname = createUserDto.NameSurname,

            }, createUserDto.Password);
            if (result.Succeeded)
                return true;
            else
                throw new UserCouldNotBeRegisteredException();
        }
    }
}
