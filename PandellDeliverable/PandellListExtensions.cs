using System; 
using System.Collections.Generic;

namespace PandellDeliverable
{
    /// <summary>
    /// This class contains extension methods that can be used generically with the IList interface.
    /// </summary>
    public static class PandellListExtensions
    {
        //use singleton pattern for random number generator resource
        //to help avoid any possible repeats in pseudorandom behaviour of generator
        private static readonly Random _generator = new Random();

        /// <summary>
        /// This extension method will randomize the positions of the object implementing the IList interface.
        /// The method uses the Fisher-Yates algorithm so the elements are moved around within the same IList object.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="source">Source object implementing IList</param>
        public static void PandellRandomize<T>(this IList<T> source)
        {
            //iterate through our list backwards
            for (int i = source.Count - 1; i >= 0; i--)
            {
                //get a random index between the begining of our list (0) and where our pointer is located (i)
                //The Max Value needs to be i + 1 because the Next() method is not inclusive of the Max Value variable
                //i.e. Next(50) will return a value between 0 and 49
                int j = _generator.Next(i + 1);

                //swap our two list elements
                source.PandellSwapElement(j, i);
            }
        }

        /// <summary>
        /// This extension method will swap the positions of two elements of the object implementing the IList interface.
        /// The parameters indexA and indexB cannot exceed the bounds of the objects element count.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="source">Source object implementing IList</param>
        /// <param name="indexA">Index to first element</param>
        /// <param name="indexB">Index to second element</param>
        public static void PandellSwapElement<T>(this IList<T> source, int indexA, int indexB)
        {
            //validate our indices
            if ((indexA > source.Count - 1) || (indexA < 0))
            {
                throw new ArgumentOutOfRangeException("indexA", "Index was out of range.  Must be non-negative and less than the size of the List");
            }

            //validate our indices
            if ((indexB > source.Count - 1) || (indexB < 0))
            {
                throw new ArgumentOutOfRangeException("indexB", "Index was out of range.  Must be non-negative and less than the size of the List");
            }

            //get our object value at index and store temporarily
            T tempElement = source[indexA];
            //now that we've saved index A's value, overwrite it with index B's value
            source[indexA] = source[indexB];
            //place index A's original value in index B's location to complete the swap
            source[indexB] = tempElement;
        }

        /// <summary>
        /// This routine will display the elements of the IList object on the console screen using the elements toString() method.
        /// Each element is separated by the optional parameter elementParameter.
        /// </summary>
        /// <param name="elementSeparator">String separator used between elements</param>
        public static void PandellConsoleDisplay<T>(this IList<T> source, string elementSeparator = ",")
        {
            //bool to record whether the loop is in it's first iteration or not
            bool firstTime = true;

            for(int i = 0; i < source.Count; i++)
            {
                if (firstTime)
                {
                    //record our first time
                    firstTime = false;
                }
                else
                {
                    //print out the separator before our element if this is not the first time in the loop
                    Console.Write(elementSeparator);
                }

                //output the item to the console
                Console.Write(source[i].ToString());
            }

            Console.WriteLine();
        }
    }
}
