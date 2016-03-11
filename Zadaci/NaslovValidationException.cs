using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadaci
{
    public class NaslovValidationException : Exception
    {
        public NaslovValidationException() : base() { }

        public NaslovValidationException(string message) : base(message) { }
    }
}