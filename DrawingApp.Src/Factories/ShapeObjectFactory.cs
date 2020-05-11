using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Interfaces;
using DrawingApp.Services;
using Microsoft.Extensions.Logging;

namespace DrawingApp.Factories
{
    public class ShapeObjectFactory: IShapeObjectFactory
    {
        private IConsoleBuffer _consoleBuffer;
        private IConsole _consoleImpl;
        private ILogger _logger;
        public ShapeObjectFactory(IConsoleBuffer consoleBuffer, IConsole consoleImpl, ILoggerFactory loggerFactory)
        {
            _consoleBuffer = consoleBuffer;
            _logger = loggerFactory.CreateLogger<ShapeObjectFactory>();
            _consoleImpl = consoleImpl;
        }
        public IShape GetShapeObject(string shapeCommand)
        {
            IShape oShape = null;

            switch (shapeCommand) 
            {
                case "R":
                    oShape = new Rectangle(_consoleBuffer);
                    _logger.LogDebug("Created rectangle");
                    break;
                case "C":
                    oShape = new Canvas(_consoleBuffer,_consoleImpl);
                    _logger.LogDebug("Created Canvas");
                    break;
                case "L":
                    oShape = new Line(_consoleBuffer);
                    _logger.LogDebug("Created Line");
                    break;
                case "B":
                    oShape = new ColorFill(_consoleBuffer);
                    _logger.LogDebug("Created ColorFill");
                    break;

            }
            return oShape;
        }
    }
}
