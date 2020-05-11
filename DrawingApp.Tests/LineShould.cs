using System;
using DrawingApp.Exceptions;
using DrawingApp.Factories;
using DrawingApp.Services;
using DrawingApp.Tests.Mocks;
using Xunit;

namespace DrawingApp.Tests
{
    public class LineShould
    {
        [Fact]
        public void Throw_InvalidShapeException_When_NoCanvas()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(-1);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(-1);
            var lineObj = new Line( mockConsoleBuffer.Object);


            //Assert
            Assert.Throws<InvalidShapeCreationException>(() => lineObj.Initialize(TestDataFactory.LineInput));
        }

        [Fact]
        public void Throw_InvalidCoordinatesException_When_OutsideCanvas()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var lineObj = new Line(mockConsoleBuffer.Object);
            

            //Act and Assert
            Assert.Throws<InvalidCoordinatesException>(() => lineObj.Initialize(TestDataFactory.LineOutsideCanvas));
        }


        [Fact]
        public void Throw_InvalidCoordinatesException_When_NotStraight()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var lineObj = new Line(mockConsoleBuffer.Object);
            
            //Assert
            Assert.Throws<InvalidCoordinatesException>(() => lineObj.Initialize(TestDataFactory.LineInputNotStraight));
        }

        [Fact]
        public void Throw_ArgumentException_When_IncorrectInput()
        {

            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(20);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(4);
            var lineObj = new Line(mockConsoleBuffer.Object);
            
            //Act and Assert
            Assert.Throws<ArgumentException>(() => lineObj.Initialize(TestDataFactory.LineInvalidInput));
        }
    }
}
