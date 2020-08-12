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
    public class GameCreateTests
    {
        [Theory]
        [InlineData(20, 20)]
        [InlineData(12, 20)]
        [InlineData(31, 28)]
        public void RandomBoard_ShouldCreateARandom2DArrayToFitGivenWidthAndHeight(int width, int height)
        {
            using (var mock = AutoMock.GetLoose())
            {               

                //Arrange                
                int expectedHeight = height;
                int expectedWidth = width;

                //Act
                var cls = mock.Create<GameCreate>();
                bool [,] actual = cls.RandomBoard(width, height);


                //Assert 
                Assert.Equal(expectedWidth, actual.GetLength(0));
                Assert.Equal(expectedHeight, actual.GetLength(1));
            }

        }
    }
}

