using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingApp.Exceptions
{
    public class InvalidShapeCreationException : System.Exception
    {
        public InvalidShapeCreationException() : base() { }
        public InvalidShapeCreationException(string message) : base(message) { }
        public InvalidShapeCreationException(string message, System.Exception inner) : base(message, inner) { }


    }
}
