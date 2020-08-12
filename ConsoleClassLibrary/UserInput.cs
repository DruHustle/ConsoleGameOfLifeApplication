using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class UserInput : IUserInput
    {
        IReadInput _readInput;
        IPrintOutput _printOutput;

        public UserInput(IReadInput readInput, IPrintOutput printOutput)
        {
            _readInput = readInput;
            _printOutput = printOutput;
        }


        public int GetValues(string s, int lowBound, int upperBound, out bool widthIsParsable)
        {
            int valueOut = 0;
            int value;

            //Get user input values 
            do
            {
                do
                {
                    Console.Clear();
                    _printOutput.Message(s);
                    value = _readInput.GetValue(out widthIsParsable);

                } while (!widthIsParsable);

                if (value>= lowBound && value <= upperBound)
                {
                    valueOut = value;
                    _printOutput.Message("Sucess.\n\nPress any key to proceed...");
                    Console.ReadKey();
                }
                else
                {
                    _printOutput.Message("Wrong entry! Enter values again.\n\nPress any key to proceed...");
                    Console.ReadKey();

                }

            } while (!(value >= lowBound && value <= upperBound));
			
			return valueOut;

        }
        

        public int GetValues(out bool generationsIsParsable)
        {
            int generationsOut = 0;
            int generations;
            do
            {
                Console.Clear();
                _printOutput.Message("\nGenerations: Enter a positive 32 bit integer value.(Max value is 2,147,483,647).");
                generations = _readInput.GetValue(out generationsIsParsable);

            } while (!(generations >= 0 && generations <= int.MaxValue));
            if (generationsIsParsable)
            {
                generationsOut = generations;
                _printOutput.Message("Sucess.\n\nPress any key to proceed...");
                Console.ReadKey();
            }
            else
            {
                _printOutput.Message("Wrong entry! Enter values again.\n\nPress any key to proceed...");
                Console.ReadKey();

            }

            return generationsOut;
 
        }


    }
}
