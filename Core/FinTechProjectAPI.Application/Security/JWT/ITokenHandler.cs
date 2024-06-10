using FinTechProjectAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Security.JWT;

public interface ITokenHandler
{
  Token CreateAccessToken(int minute, AppUser user);
}
