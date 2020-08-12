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
    public class GameCountTests
    {
        [Theory]
        [InlineData(5,4,10,10,2)]
        [InlineData(1, 3, 10, 10, 7)]
        [InlineData(8, 6, 10, 10, 4)]
        [InlineData(4, 9, 10, 10, 3)]
        [InlineData(3, 0, 10, 10, 3)]
        [InlineData(8, 2, 10, 10, 6)]
        [InlineData(7, 4, 10, 10, 5)]
        [InlineData(9, 8, 10, 10, 2)]
        [InlineData(0, 4, 10, 10, 6)]
        public void LiveNeighbours_ShouldCountLiveNeighboursBasedOnGameOfLifeRules(int x, int y, int width, int height, int expected)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                bool[,] board = new bool[10, 10];
                board[1,0] = true; board[7, 1] = true;
                board[1,1] = true; board[7, 2] = true;
                board[1,2] = true; board[7, 3] = true;
                board[2,3] = true; board[8, 4] = true;
                board[2,4] = true; board[8, 5] = true;
                board[2,5] = true; board[8, 6] = true;
                board[3,6] = true; board[8, 7] = true;
                board[3,7] = true; board[8, 1] = true;
                board[3,8] = true; board[9, 2] = true;
                board[3,9] = true; board[9, 3] = true;
                board[4,0] = true; board[9, 4] = true;
                board[4,0] = true; board[9, 5] = true;
                board[4,1] = true; board[9, 6] = true;
                board[5,1] = true; board[0, 7] = true;
                board[5,2] = true; board[0, 1] = true;
                board[5,2] = true; board[0, 2] = true;
                board[6,3] = true; board[0, 3] = true;
                board[6,3] = true; board[0, 4] = true;
                board[6,4] = true; board[1, 3] = true;
                board[7,4] = true; board[1, 4] = true;


                //Act
                var cls = mock.Create<GameCount>();
                int actual = cls.LiveNeighbours(x, y, width, height, board);


                //Assert 
                Assert.Equal(expected, actual);
            }

        }
    }
}
