using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Exceptions
{
    public class UserCouldNotBeRegisteredException: Exception
    {
        public UserCouldNotBeRegisteredException() : base("Kullanıcı oluşturulurken beklenmeyen bir hatayla karşılaşıldı")
        {

        }

        public UserCouldNotBeRegisteredException(string? message) : base(message)
        {
        }

        public UserCouldNotBeRegisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
