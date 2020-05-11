using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Interfaces;
using Moq;

namespace DrawingApp.Tests.Mocks
{
    public static class MockConsoleBuffer
    {
        public static Mock<IConsoleBuffer> Default()
        {
            var mock = new Mock<IConsoleBuffer>();

            
            mock.Setup(x => x.WriteCharAtLocation(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>()))
                .Verifiable();

            mock.Setup(x => x.ReadCharAtLocation(It.IsAny<int>(), It.IsAny<int>()))
                .Verifiable();

            return mock;
        }
    }
}
