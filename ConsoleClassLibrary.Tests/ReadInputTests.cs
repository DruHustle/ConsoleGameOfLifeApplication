using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleClassLibrary.Tests
{
    public class ReadInputTests
    {
        [Theory]
        [InlineData("1035155485", true)]
        [InlineData("2147483600", true)] //max edge case
        [InlineData("20000", true)] //min edge case
        public void GetValue_ShouldReadStringFromConsole(string s, bool expected)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange  

                int stringNumber = Convert.ToInt32(s);
                var input = new StringReader(s);
                Console.SetIn(input);

                var task = Task.Run(() =>
                {
                    //Act
                    var cls = mock.Create<ReadInput>();
                    int value = cls.GetValue(out bool actual);

                    //Assert 
                    Assert.Equal(expected, actual);
                    Assert.Equal(stringNumber, value);

                });
                bool isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(1000));


            }

        }

        [Theory]
        [InlineData("mama 4 Mia")]
        [InlineData("12345678/*@#$%^&*")]
        public void GetValue_ShouldTimeOutIfValuesNotParsable(string s)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange                
                var input = new StringReader(s);
                Console.SetIn(input);

                var task = Task.Run(() =>
                {
                    //Act
                    var cls = mock.Create<ReadInput>();
                    int value = cls.GetValue(out bool actual);
                });
                bool isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(1000));

                //Assert 
                Assert.False(isCompletedSuccessfully);
            }

        }
    }
}
