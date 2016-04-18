using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.BusinessExceptions
{
    public class InvalidAmountException : Exception
    {
        public string ErrorMessage { get; private set; }

        public InvalidAmountException(string message)
        {
            this.ErrorMessage = message;
        }
    }
}
