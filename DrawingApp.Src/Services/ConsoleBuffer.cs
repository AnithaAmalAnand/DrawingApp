using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using DrawingApp.Interfaces;

namespace DrawingApp.Services
{
    public class ConsoleBuffer : IConsoleBuffer
    {
        private char[,] buffer = new char[85, 30];

        public int CanvasLength { get; set; }

        public int CanvasWidth { get; set; }

        public ConsoleBuffer()
        {
            CanvasWidth = -1;
            CanvasLength = -1;
        }

        public char ReadCharAtLocation(int x, int y)
        {
            return buffer[x, y];

        }

        public void WriteCharAtLocation(int x, int y, char c)
        {
            buffer[x, y] = c;

        }

        public void WriteToScreen()
        {
            //traversal  
            for (int i = 0; i < 85; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(buffer[i, j]);
                }

            }
        }
    }
}
