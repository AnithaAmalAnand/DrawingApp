using System;
using System.Collections.Generic;
using System.Text;
using DrawingApp.Exceptions;
using DrawingApp.Factories;
using DrawingApp.Services;
using DrawingApp.Tests.Mocks;
using Xunit;

namespace DrawingApp.Tests
{
    public class CanvasShould
    {
        [Fact]
        public void Throw_InvalidCoordinatesException_When_WrongCoordinates()
        {

            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            var mockConsole = MockConsole.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(-1);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(-1);
            //Act
            var canvasObj = new Canvas(mockConsoleBuffer.Object,mockConsole.Object);

            //Assert
            Assert.Throws<InvalidCoordinatesException>(() => canvasObj.Initialize(TestDataFactory.CanvasLargeInput));

        }


        [Fact]
        public void Throw_ArgumentException_When_IncorrectInput()
        {
            //Arrange
            var mockConsoleBuffer = MockConsoleBuffer.Default();
            mockConsoleBuffer.Setup(x => x.CanvasWidth).Returns(-1);
            mockConsoleBuffer.Setup(x => x.CanvasLength).Returns(-1);

            var mockConsole = MockConsole.Default();

            //Act
            var canvasObj = new Canvas(mockConsoleBuffer.Object,mockConsole.Object);

            //Assert
            Assert.Throws<ArgumentException>(() => canvasObj.Initialize(TestDataFactory.CanvasInvalidInput));
        }
    }

}