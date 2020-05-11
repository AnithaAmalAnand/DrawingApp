using DrawingApp.Interfaces;
using System;
namespace DrawingApp.Services
{
    public class ConsoleImpl: IConsole {
        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public ConsoleImpl() {
            StartCol = Console.CursorLeft;
            StartRow = Console.CursorTop;
        }
    }
}