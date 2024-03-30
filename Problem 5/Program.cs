namespace DesignPatters
{

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create IBM stock and attach investors

            //Stock List
            IBM ibm = new IBM("IBM", 120.00);

            //Investor List
            Investor berkshirre = new Investor("Berkshire");
            Investor sorros = new Investor("Sorros");

            // Attaching and Detaching Investors in Stocks
            ibm.Attach(berkshirre);
            ibm.Attach(sorros);
            ibm.Detach(berkshirre);

            // Fluctuating prices will notify investors

            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;



            // Please complete the implementation of the code using appropriate design pattern to get following Expected Output on Console

            //Notified Sorros of IBM's change to $120.10

            //Notified Sorros of IBM's change to $121.00

            //Notified Sorros of IBM's change to $120.50

            //Notified Sorros of IBM's change to $120.75



            // Wait for user
            Console.ReadKey();
        }
    }

    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();

        // Constructor

        public Stock(string symbol, double price)
        {
            // Implement this.
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(IInvestor investor)
        {
            // Implement this.
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            // Implement this.
            investors.Remove(investor);
        }

        public void Notify()
        {
            // Implement this.
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }
        }

        // Gets or sets the price

        public double Price
        {
            get { return price; }
            set
            {
                // Implement this.
                price = value;
                Notify();
            }
        }

        // Gets the symbol

        public string Symbol
        {
            get { return symbol; }
        }
    }

    public class IBM : Stock
    {
        // Constructor

        // Implement this.
        public IBM(string symbol, double price) : base(symbol, price)
        {

        }

    }

    public interface IInvestor
    {
        void Update(Stock stock);
    }

    public class Investor : IInvestor
    {
        private string name;

        // Constructor
        public Investor(string name)
        {
            this.name = name;
        }

        // Implement this.
        public void Update(Stock stock)
        {
            // Implement this.
            Console.WriteLine("Notified {0} of {1}'s change to ${2}", name, stock.Symbol, stock.Price.ToString("0.00"));
        }
    }
}
