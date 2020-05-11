using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DrawingApp.Exceptions;
using DrawingApp.Interfaces;

namespace DrawingApp.Services
{
    public class ColorFill: AbstractShape
    {
        private int _x;
        private int _y;
        private char _c;


        public ColorFill( IConsoleBuffer consoleBuffer)
        {
            _consoleBuffer = consoleBuffer;
        }

        public override void Initialize(string[] input)
        {
            if (input.Length != 4)
            {
                throw new ArgumentException("Color fill string must have 4 arguments");
            }

            _x = int.Parse(input[1]);
            _y = int.Parse(input[2]);
            _c = input[3][0];

            if (_consoleBuffer.CanvasWidth < 0 || _consoleBuffer.CanvasLength < 0)
            {
                throw new InvalidShapeCreationException("Canvas not created yet");
            }

            if (IsOutsideCanvas(_x, _y))
            {
                throw new InvalidCoordinatesException("Coordinates lie outside the canvas");
            }
        }

        public override void Draw()
        {

            //todo: to complete this to reflect required logic - may be can use Stack object
            for (int i = 1; i <= _consoleBuffer.CanvasLength; i++)
            {
                for (int j = 1; j <= _consoleBuffer.CanvasWidth + 1; j++)
                {
                    if (_consoleBuffer.ReadCharAtLocation(i,j) == default(char))
                    {
                        _consoleBuffer.WriteCharAtLocation(i,j, _c);    
                    }
                }
            }  
         
        }
        
    }
}
