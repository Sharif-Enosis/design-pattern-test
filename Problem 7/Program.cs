﻿namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var regularOrder = new RegularOrder();
            Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var preOrder = new PreOrder();
            Console.WriteLine(preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var premiumOrder = new Premium(preOrder);
            var mixedOrder = new Membership(premiumOrder);

            Console.WriteLine(mixedOrder.CalculateTotalOrderPrice().ToString("0.00"));

            //How to allow an additional
            // 10 percent discount to our premium users
            // and 20 percent discount to our membership users
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }


    public abstract class OrderBase
    {
        protected List<Product> products = new List<Product>
        {
            new Product ( "Phone",  587),
            new Product ( "Tablet",  800),
            new Product ( "PC",  1200)
        };

        public abstract double CalculateTotalOrderPrice();
    }

    public class Premium : OrderBase
    {
        private OrderBase orderbase;

        public Premium(OrderBase orderbase)
        {
            this.orderbase = orderbase;
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating Premium Discount");
            return orderbase.CalculateTotalOrderPrice() * 0.9;
        }
    }

    public class Membership : OrderBase
    {
        private OrderBase orderbase;

        public Membership(OrderBase orderbase)
        {
            this.orderbase = orderbase;
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating Membership Discount");
            return orderbase.CalculateTotalOrderPrice() * 0.8;
        }
    }

    public class RegularOrder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a regular order");
            return products.Sum(x => x.Price);
        }
    }

    public class PreOrder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a preorder.");
            return products.Sum(x => x.Price) * 0.9;
        }
    }
}