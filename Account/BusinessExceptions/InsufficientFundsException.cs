
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.BusinessExceptions
{
    public class InsufficientFundsException : ApplicationException
    {
        public string ErrorMessage { get; private set; }

        public InsufficientFundsException(string message)
        {
            this.ErrorMessage = message;
        }
    }
}
