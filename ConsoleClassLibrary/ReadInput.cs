using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleClassLibrary
{
    public class ReadInput : IReadInput
    {
        public int GetValue(out bool isParsable)
        {
            string Input = Console.ReadLine().Trim();
            isParsable = Int32.TryParse(Input, out int number);

            if (!isParsable)
            {
                Console.WriteLine("Error! Could not be parsed. Please enter values again.\n\nPress any key to proceed...");
                Console.ReadKey();
            }
             
            return number;
        }
    }
}
