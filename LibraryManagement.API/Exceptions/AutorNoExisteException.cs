using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.API.Exceptions
{
    public class AutorNoExisteException : Exception
    {
        public AutorNoExisteException()
            : base("El autor no está registrado")
        {
        }
    }
}