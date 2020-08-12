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
    public class GameConsoleTests
    {
        [Theory]
        [InlineData(20, 20)]
        public void Initialize_ShouldSetTheConsoleSize(int width, int height)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                int expexctedWidth = (width*2)+1;
                int expectedHeight = height+1;

                try
                {
                    //Act
                    var cls = mock.Create<GameConsole>();
                    cls.Initialize(width, height);

                }catch(Exception){ };                

                int actualWidth = Console.WindowWidth;
                int actualHeight = Console.WindowHeight;


                //Assert 
                Assert.Equal(expexctedWidth, actualWidth);
                Assert.Equal(expectedHeight, actualHeight);

            }

        }
    }
}