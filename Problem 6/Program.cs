using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem:  We have to make sure, TheOracle object has only one instance. Please select a design pattern that suits best.

            // Change following code if required.
            TheOracle s1 = TheOracle.GetTheOracle();
            TheOracle s2 = TheOracle.GetTheOracle();

            if (s1 == s2)
            {
                Console.WriteLine("One Oracle maintaining the Peace.");
            }
            else
            {
                Console.WriteLine("Opps, Two oracle can't exist.");
            }
        }
    }
    sealed class TheOracle
    {
        private static TheOracle theOracle = null;
        // Change following code if required.
        private TheOracle()
        {
        }

        public static TheOracle GetTheOracle()
        {
            if(theOracle == null)
            {
                theOracle = new TheOracle();
            }

            return theOracle;
        }



        public void ManipulateMatrix()
        {
            Console.WriteLine("Manipulate every living thing on matrix");
        }
    }
}