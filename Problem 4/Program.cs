using System;

namespace DesignPatterns
{
    class MainApp
    {
        static void Main()
        {
            IMembership membership = null;
            Console.WriteLine("Which Membership do you want?");
            string type = Console.ReadLine();

            membership = new MembershipFactory().CreateMembership(type);

            Console.WriteLine(membership.getFees());
            Console.ReadLine();

            // Problem 1: The main method is tightly coupled.
            // Problem 2: In Future if needed one more type we will be needing to modify the main method with one extra else if


            // What design pattern we can use to eliminate the following two problems mentioned.

        }
    }

    public class MembershipFactory
    {
        public IMembership CreateMembership(string type)
        {
            if (type == "monthly")
            {
                return new MonthlyMembership();
            }
            else if (type == "yearly")
            {
               return new YearlyMembership();
            }
            else
            {
                Console.WriteLine("Wrong Input");
                return null;
            }
        }
    }

    public interface IMembership
    {
        double getFees();
    }

    public class MonthlyMembership: IMembership
    {
        public double getFees()
        {
            return 10.00;
        }
    }

    public class YearlyMembership : IMembership
    {
        public double getFees()
        {
            return 80.00;
        }
    }
}
