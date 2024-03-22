using System;

namespace DesignPatterns
{   
    class Program
    {
        static void Main(string[] args)
        {
            //Problem:  We have to make sure, TheOracle object has only one instance. Please select a design pattern that suits best.
            
            // Change following code if required.
            TheOracle s1 = new TheOracle();
            TheOracle s2 = new TheOracle();

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
    class TheOracle
    {
        // Change following code if required.
        public TheOracle()
        { 
        } 

        public void ManipulateMatrix()
        {
            Console.WriteLine("Manipulate every living thing on matrix");
        }
    }
}