using System;
using System.Collections.Generic;
using System.Linq;

namespace PandellDeliverable
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a sequential integer list
            List<int> testList = Enumerable.Range(1, 10000).ToList();

            //display sequential list
            testList.PandellConsoleDisplay();

            //randomize the sequential integer list
            testList.PandellRandomize<int>();

            //display the randomized list
            testList.PandellConsoleDisplay<int>();

            Console.Read();
        }
    }
}
