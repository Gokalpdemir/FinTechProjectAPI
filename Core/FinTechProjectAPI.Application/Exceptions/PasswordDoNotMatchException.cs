using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Exceptions
{
    public class PasswordDoNotMatchException : Exception
    {
        public PasswordDoNotMatchException() : base("Şifreler Eşleşmiyor") 
        {
            
        }
        public PasswordDoNotMatchException(string? message) : base(message)
        {
        }

        public PasswordDoNotMatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
