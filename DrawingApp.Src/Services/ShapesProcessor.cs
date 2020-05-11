using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Exceptions;
using DrawingApp.Factories;
using DrawingApp.Interfaces;

namespace DrawingApp.Services
{
    public class ShapesProcessor: IShapesProcessor
    {
        protected static int _startCol;
        protected static int _startRow;
        private IShapeObjectFactory _shapeObjectFactory;
        private IConsoleBuffer _consoleBuffer;

        public ShapesProcessor(IShapeObjectFactory shapeObjectFactory, IConsoleBuffer consoleBuffer, IConsole consoleImpl)
        {
            _shapeObjectFactory = shapeObjectFactory;
            _consoleBuffer = consoleBuffer;
            _startCol = consoleImpl.StartCol;
            _startRow = consoleImpl.StartRow;
        }
        public void Process()
        {
            while (true)
            {
                try
                {
                    ResetInputLine(_startCol, _startRow);
                    Console.Write("enter command:");
                    var input = Console.ReadLine();

                    if (input == null) continue;
                    if (input.ToUpper().Equals("Q")) break;

                    string[] splitString = input.Split(' ', StringSplitOptions.None);
                    var shape = _shapeObjectFactory.GetShapeObject(splitString[0]);

                    shape.Initialize(splitString);
                    shape.Draw();
                    _consoleBuffer.WriteToScreen();
                    
                }
                catch (ArgumentException ex)
                {
                    ResetInputLine(0, 25);
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidCoordinatesException icex)
                {
                    ResetInputLine(0, 25);
                    Console.WriteLine(icex.Message);
                }
                catch (InvalidShapeCreationException scex)
                {
                    ResetInputLine(0, 25);
                    Console.WriteLine(scex.Message);
                }
            }
        }

        private void ResetInputLine(int startCol, int startRow)
        {
            Console.SetCursorPosition(startCol, startRow);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(startCol, startRow);
        }

    }
}
