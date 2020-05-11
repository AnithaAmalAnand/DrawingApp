using System;
using DrawingApp.Exceptions;
using DrawingApp.Services;
using DrawingApp.Tests.Mocks;
using Xunit;

namespace DrawingApp.Tests
{
    public class ColorFillShould
    {
        [Fact]
        public void Throw_InvalidShapeException_When_NoCanvas()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(-1);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(-1);
            var colorFillObj = new ColorFill(mockConsoleBuffer.Object);


            //Assert
            Assert.Throws<InvalidShapeCreationException>(() => colorFillObj.Initialize(TestDataFactory.ColorFillInput));
        }

        [Fact]
        public void Throw_InvalidCoordinatesException_When_OutsideCanvas()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var colorFillObj = new ColorFill(mockConsoleBuffer.Object);

            //Assert
            Assert.Throws<InvalidCoordinatesException>(() => colorFillObj.Initialize(TestDataFactory.ColorFillOutsideCanvas));
        }


        [Fact]
        public void Throw_ArgumentException_When_IncorrectInput()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var colorFillObj = new ColorFill(mockConsoleBuffer.Object);

            //Assert
            Assert.Throws<ArgumentException>(() => colorFillObj.Initialize(TestDataFactory.ColorFillInvalidInput));
        }
    }
}