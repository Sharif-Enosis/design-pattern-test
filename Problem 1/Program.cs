//Real World example

using System;

namespace DesignPatterns

{
    class Program
    {
        static void Main()
        {

            RoundHole rhole = new RoundHole(5);
            RoundPeg rpeg = new RoundPeg(5);

            Console.WriteLine(rhole.fits(rpeg)); // True

            SquarePeg small_sqpeg = new SquarePeg(5);
            SquarePeg large_sqpeg = new SquarePeg(10);

            Console.WriteLine(rhole.fits(new SquarePegAdapter(small_sqpeg)));
            Console.WriteLine(rhole.fits(new SquarePegAdapter(large_sqpeg)));

            //How can we integrate the SquarePeg with RoundHole


            Console.ReadKey();
        }
    }

    class RoundHole
    {
        protected double radius;

        public RoundHole(double radius)
        {
            this.radius = radius;
        }

        public double getRadius()
        {
            return this.radius;
        }

        public bool fits(RoundPeg roundPeg)
        {
            return this.getRadius() >= roundPeg.getRadius();
        }
    }

    public class RoundPeg
    {
        protected double radius;

        public RoundPeg()
        {
        }

        public RoundPeg(double radius)
        {
            this.radius = radius;
        }

        public virtual double getRadius()
        {
            return this.radius;
        }
    }

    public class SquarePeg
    {
        protected double width;

        public SquarePeg(double width)
        {
            this.width = width;
        }

        public double getWidth()
        {
            return this.width;
        }
    }

    public class SquarePegAdapter: RoundPeg
    {
        private SquarePeg squarePeg;

        public SquarePegAdapter(SquarePeg squarePeg)
        {
            this.squarePeg = squarePeg;
        }
        
        public override double getRadius()
        {
            return squarePeg.getWidth()/Math.Sqrt(2);
        }
    }
}