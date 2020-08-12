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
    public class UserInputTests
    {

        [Theory]
        [InlineData("100")]
        public void GetValue_ShouldCallBothIReadInputAndIPrintOutputAtLeastOnce(string s)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                bool readSuccess;
                int lowBound =int.MinValue;
                int upperBound =int.MaxValue;

                mock.Mock<IReadInput>()
                    .Setup(x => x.GetValue(out readSuccess)).Returns(123);
                mock.Mock<IPrintOutput>()
                    .Setup(x => x.Message("Hello Mr Duncan"));

                var task1 = Task.Run(() =>
                {
                    //Act
                    var cls = mock.Create<UserInput>();
                    int valueOut = cls.GetValues(s, lowBound, upperBound, out bool widthIsParsable);

                });
                bool getValuesIsCompletedSuccessfully = task1.Wait(TimeSpan.FromMilliseconds(1000));

                var task2 = Task.Run(() =>
                {
                    //Act
                    var cls = mock.Create<UserInput>();
                    int valueOut = cls.GetValues( out bool widthIsParsable);

                });
                bool getValuesOverloadIsCompletedSuccessfully = task2.Wait(TimeSpan.FromMilliseconds(1000));

                //Assert 
                mock.Mock<IReadInput>()
                    .Verify(x => x.GetValue(out readSuccess), Times.AtLeastOnce);
                mock.Mock<IPrintOutput>()
                    .Verify(x => x.Message(s), Times.AtLeastOnce);
            }
                                 
        }

        
        [Theory]
        [InlineData("12155485", true)]
        [InlineData("100", true)]
        [InlineData("-28", true)]
        [InlineData("0", true)]
        public void GetValues_ShouldReadValidEntries(string s, bool expectedBool)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                bool readSuccess;
                int expected = Convert.ToInt32(s);
                int lowBound = int.MinValue;
                int upperBound = int.MaxValue;

                int valueOut = 0;
                bool isParsable = false;

                var output = new StringWriter();
                Console.SetOut(output);

                mock.Mock<IReadInput>()
                    .Setup(x => x.GetValue(out readSuccess));
                mock.Mock<IPrintOutput>()
                    .Setup(x => x.Message(s));

                var task = Task.Run(() =>
                {

                    //Act
                    var cls = mock.Create<UserInput>();
                    valueOut = cls.GetValues(s, lowBound, upperBound,  out isParsable);

                });

                bool isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(1000));

                if (isCompletedSuccessfully)
                {
                    //Assert 
                    Assert.Equal(expected, valueOut);
                    Assert.Equal(expectedBool, isParsable);
                    Assert.Equal("Sucess.\n\nPress any key to proceed...", output.ToString().Remove(output.ToString().Length - 2, 2));

                }
                
                
            }

        }


        [Theory]
        [InlineData("12155485", true)]
        [InlineData("100", true)]
        [InlineData("-28", true)]
        [InlineData("0", true)]
        public void GetValuesOverload_ShouldReadValidEntries(string s, bool expectedBool)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                bool readSuccess;
                int expected = Convert.ToInt32(s);
                int valueOut = 0;
                bool isParsable = false;

                var output = new StringWriter();
                Console.SetOut(output);

                mock.Mock<IReadInput>()
                    .Setup(x => x.GetValue(out readSuccess));
                mock.Mock<IPrintOutput>()
                    .Setup(x => x.Message(s));

                var task = Task.Run(() =>
                {
                    //Act
                    var cls = mock.Create<UserInput>();
                    valueOut = cls.GetValues( out isParsable);

                });
                bool isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(1000));

                if (isCompletedSuccessfully)
                {
                    //Assert 
                    Assert.Equal(expected, valueOut);
                    Assert.Equal(expectedBool, isParsable);
                    Assert.Equal("Sucess.\n\nPress any key to proceed...", output.ToString().Remove(output.ToString().Length - 2, 2));

                }    

            }

        }


        [Theory]
        [InlineData("2000000000000000000")]
        [InlineData("-20000000000000000000")]
        [InlineData("12155485")]
        [InlineData("mama 4 Mia")]
        [InlineData("12345678/*@#$%^&*")]
        public void UserInput_ShouldTimeOutIfInValidEntries(string s)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange   
                bool readSuccess;
                int lowBound = int.MinValue;
                int upperBound = 10;

                mock.Mock<IReadInput>()
                    .Setup(x => x.GetValue(out readSuccess));
                mock.Mock<IPrintOutput>()
                    .Setup(x => x.Message(s));

                var task = Task.Run(() =>
                {
                   //Act
                   var cls = mock.Create<UserInput>();

                    //Assert 
                    Assert.Throws<OverflowException>(()=>cls.GetValues(s, lowBound, upperBound, out bool isParsable));
                                        
                });
                bool isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(2000));

            }

        }

        [Theory]
        [InlineData("2000000000000000000")]
        [InlineData("-20000000000000000000")]
        [InlineData("mama 4 Mia")]
        [InlineData("12345678/*@#$%^&*")]
        public void GetValuesOverload_ShouldTimeOutIfInValidEntries(string s)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange   
                bool readSuccess;

                mock.Mock<IReadInput>()
                    .Setup(x => x.GetValue(out readSuccess));
                mock.Mock<IPrintOutput>()
                    .Setup(x => x.Message(s));

                var task = Task.Run(() =>
                {
                    //Act
                    var cls = mock.Create<UserInput>();

                    //Assert 
                    Assert.Throws<OverflowException>(() => cls.GetValues( out bool isParsable));

                });
                bool isCompletedSuccessfully = task.Wait(TimeSpan.FromMilliseconds(2000));

            }

        }

    }
}
