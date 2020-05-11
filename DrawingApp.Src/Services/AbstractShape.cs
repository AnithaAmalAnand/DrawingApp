using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Exceptions;
using DrawingApp.Interfaces;

namespace DrawingApp.Services
{
    public abstract class AbstractShape: IShape
    {
        protected IConsoleBuffer _consoleBuffer;
        public abstract void Draw();

        public abstract void Initialize(string[] input);

        protected bool IsOutsideCanvas(int x1, int y1)
        {
            return x1 < 1 || x1 > _consoleBuffer.CanvasLength || y1 < 1 || y1 > _consoleBuffer.CanvasWidth;
        }
        
        public void DrawLine(int x1, int y1, int x2, int y2, char c, int rowOffSet = 0)
        {

            if (x1 == x2)
            {
                //Vertical line
                for (int i = y1; i <= y2; i++)
                {
                    _consoleBuffer.WriteCharAtLocation(x1, i + rowOffSet,c); 
                }

            }
            else if (y1 == y2)
            {
                // Horizontal Line
                for (int i = x1; i <= x2; i++)
                {
                    _consoleBuffer.WriteCharAtLocation(i, y1 + rowOffSet, c);
                }
            }
            else
            {
                throw new InvalidCoordinatesException("Only straight lines are allowed");
            }
        }
    }
}
