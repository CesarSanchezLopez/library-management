using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.API.Exceptions
{
    public class MaxLibrosException : Exception
    {
        public MaxLibrosException()
            : base("No es posible registrar el libro, se alcanzó el máximo permitido.")
        {
        }
    }
}