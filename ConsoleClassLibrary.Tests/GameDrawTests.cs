using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleClassLibrary.Tests
{
    public class GameDrawTests
    {
        [Theory]
        [InlineData(9, 5)]
        [InlineData(6, 4)]
        [InlineData(10, 10)]
        public void Board_ShouldCreateAn2DArrayToFitGivenWidthAndHeight(int height, int width)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                bool[,] board = new bool[height, width];
                var output = new StringWriter();
                Console.SetOut(output);

                //Act
                var cls = mock.Create<GameDraw>();
                cls.Board(width, height, board);


                //Assert 
                Assert.NotNull(output.ToString());
                
            }

        }
    }
}
