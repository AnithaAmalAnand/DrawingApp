using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingApp.Exceptions
{
    
    public class InvalidCoordinatesException : System.Exception
    {
        public InvalidCoordinatesException() : base() { }
        public InvalidCoordinatesException(string message) : base(message) { }
        public InvalidCoordinatesException(string message, System.Exception inner) : base(message, inner) { }

        
    }
}
