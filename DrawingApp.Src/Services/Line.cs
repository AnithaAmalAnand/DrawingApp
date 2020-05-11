using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Exceptions;
using DrawingApp.Interfaces;

namespace DrawingApp.Services
{
    public class Line: AbstractShape
    {
        private char _c;
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        public Line(IConsoleBuffer consoleBuffer)
        {
            _consoleBuffer = consoleBuffer;
        }

        public override void Initialize(string[] input)
        {
            if (input.Length != 5)
            {
                throw new ArgumentException("Line creation string must have 5 arguments");
            }

            _x1 = int.Parse(input[1]);
            _y1 = int.Parse(input[2]);
            _x2 = int.Parse(input[3]);
            _y2 = int.Parse(input[4]);
            _c = 'x';

            if (_consoleBuffer.CanvasWidth < 0 || _consoleBuffer.CanvasLength < 0)
            {
                throw new InvalidShapeCreationException("Canvas not created yet");
            }

            if (IsOutsideCanvas(_x1, _y1))
            {
                throw new InvalidCoordinatesException("Coordinates lie outside the canvas");
            }

            if (IsOutsideCanvas(_x2, _y2))
            {
                throw new InvalidCoordinatesException("Coordinates lie outside the canvas");
            }
        }

        public override void Draw()
        {
            DrawLine(_x1, _y1, _x2, _y2, _c , 1);
        }
    }
}
