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
        }

        public void Attach(IInvestor investor)
        {
            // Implement this.
        }

        public void Detach(IInvestor investor)
        {
            // Implement this.
        }

        public void Notify()
        {
            // Implement this.
        }

        // Gets or sets the price

        public double Price
        {
            get { return price; }
            set
            {
                // Implement this.
                
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
        
    }

    public interface IInvestor
    {
        void Update(Stock stock);
    }

    public class Investor : IInvestor
    {
        private string name;

        // Constructor

        // Implement this.
        

        public void Update(Stock stock)
        {
            // Implement this.
        }
    }
}
