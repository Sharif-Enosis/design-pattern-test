//Real World example

using System;

namespace DesignPatterns

{
    class MainApp
    {
        static void Main()
        {

            RoundHole rhole = new RoundHole(5);
            RoundPeg rpeg = new RoundPeg(5);

            Console.WriteLine(rhole.fits(rpeg)); // True

            SquarePeg small_sqpeg = new SquarePeg(5);
            SquarePeg large_sqpeg = new SquarePeg(10);


            //Console.WriteLine(rhole.fits(small_sqpeg));

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

    class RoundPeg
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

    class SquarePeg
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
}