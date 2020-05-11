using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Exceptions;
using DrawingApp.Factories;
using DrawingApp.Interfaces;

namespace DrawingApp.Services
{
    public class Canvas: AbstractShape
    {
        private readonly int _startRow;
        private readonly int _startCol;

        private int _canvasLength;
        private int _canvasWidth;
        
        
        public Canvas(IConsoleBuffer consoleBuffer, IConsole consoleImpl)
        {
            _consoleBuffer = consoleBuffer;
            _startRow = consoleImpl.StartRow;
            _startCol = consoleImpl.StartCol;
        }


        public override void Initialize(string[] input)
        {
            if (input.Length != 3)
            {
                throw new ArgumentException("Canvas creation string must have 3 arguments");
            }

            _canvasLength = int.Parse(input[1]);
            _canvasWidth = int.Parse(input[2]);

            if (_canvasLength > 80 || _canvasWidth > 25)
            {
                _canvasLength = -1;
                _canvasWidth = -1;
                throw new InvalidCoordinatesException("Max size of canvas is 80 * 25");
            }
        }

        public override void Draw()
        {
         
            _consoleBuffer.CanvasLength = _canvasLength;
            _consoleBuffer.CanvasWidth = _canvasWidth;
            //top line
            DrawLine(_startCol, _startRow,
                _startCol + _canvasLength, _startRow,'-');

            
            //left line
            DrawLine(_startCol, _startRow + 1,
                _startCol, _startRow + _canvasWidth, '|');

            //right line
            DrawLine(_startCol + _canvasLength, _startRow + 1,
                _startCol + _canvasLength, _startRow + _canvasWidth, '|');

            //bottom line 
            DrawLine(_startCol, _startRow + _canvasWidth + 1,
                _startCol + _canvasLength, _startRow + _canvasWidth + 1, '-');


        }
    }
}
