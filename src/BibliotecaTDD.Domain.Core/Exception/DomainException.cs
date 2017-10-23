using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Domain.Core.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
