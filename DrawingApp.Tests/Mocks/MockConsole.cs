using DrawingApp.Interfaces;
using Moq;

namespace DrawingApp.Tests.Mocks
{
    public static class MockConsole
    {
        public static Mock<IConsole> Default()
        {
            var mock = new Mock<IConsole>();

            
            mock.Setup(x => x.StartRow).Returns(1);
            mock.Setup(x => x.StartCol).Returns(0);

            return mock;
        }
    }
}