using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException():base("Girdiğiniz bilgiler ile bir kullanıcı bulunamadı")
        {
            
        }
        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
