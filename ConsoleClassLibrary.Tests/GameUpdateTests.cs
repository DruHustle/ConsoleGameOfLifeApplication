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
    public class GameUpdateTests
    {
        [Theory]
        [InlineData(20,20)]
        [InlineData(12, 20)]
        [InlineData(31, 28)]
        public void Board_ShouldReadEachCellinTheGivenWindow(int width, int height)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                bool [,]board = new bool[width, height];

                //Arrange                
                mock.Mock<IGameCount>()
                    .Setup(x => x.LiveNeighbours(10, 10, width, height, board));

                //Act
                var cls = mock.Create<GameUpdate>();
                cls.Board(width, height, board, out bool[,] actual);

                //Assert 
                mock.Mock<IGameCount>()
                    .Verify(x => x.LiveNeighbours(10, 10, width, height, board),Times.AtLeastOnce);
                Assert.NotEmpty(actual);
                Assert.NotNull(actual);
            }

        }
    }
}