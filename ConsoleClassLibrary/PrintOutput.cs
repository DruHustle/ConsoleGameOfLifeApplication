using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class PrintOutput : IPrintOutput
    {
        
        public void Message(string s)
        {
            Console.WriteLine(s);
        }


    }
}
