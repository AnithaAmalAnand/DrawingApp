using System;
using DrawingApp.Exceptions;
using DrawingApp.Factories;
using DrawingApp.Services;
using DrawingApp.Tests.Mocks;
using Xunit;

namespace DrawingApp.Tests
{
    public class RectangleShould
    {
        [Fact]
        public void Throw_InvalidShapeException_When_NoCanvas()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(-1);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(-1);
            var rectObj = new Rectangle(mockConsoleBuffer.Object);


            //Assert
            Assert.Throws<InvalidShapeCreationException>(() => rectObj.Initialize(TestDataFactory.RectangleInput));
        }

        [Fact]
        public void Throw_InvalidCoordinatesException_When_OutsideCanvas()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var rectObj = new Rectangle(mockConsoleBuffer.Object);


            //Assert
            Assert.Throws<InvalidCoordinatesException>(() => rectObj.Initialize(TestDataFactory.RectangleOutsideCanvas));
        }

        [Fact]
        public void Throw_ArgumentException_When_IncorrectInput()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var rectObj = new Rectangle(mockConsoleBuffer.Object);

            //Act and Assert
            Assert.Throws<ArgumentException>(() => rectObj.Initialize(TestDataFactory.RectangleInvalidInput));

            
        }
    }
}