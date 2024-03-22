namespace DesignPatterns
{

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create book

            Book book = new Book("ERIC JORGENSON", "THE ALMANACK OF NAVAL RAVIKANT", 10);
            book.Display();

            // Create movie

            Movie movie = new Movie("Karzan Kader", "Bekas", 23, 97);
            movie.Display();

            // Implement the Transform and Borrowable class to Make movie borrowable, then borrow and display using below codes from main function

            Console.WriteLine("\nMaking Movie borrowable:");

            Borrowable borrowvideo = new Borrowable(movie);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();

            // Wait for user

            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Component' abstract class
    /// </summary>

    public abstract class LibraryItem
    {
        private int numCopies;

        public int NumCopies
        {
            get { return numCopies; }
            set { numCopies = value; }
        }

        public abstract void Display();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>

    public class Book : LibraryItem
    {
        private string author;
        private string title;

        // Constructor

        public Book(string author, string title, int numCopies)
        {
            this.author = author;
            this.title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", author);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>

    public class Movie : LibraryItem
    {
        private string director;
        private string title;
        private int playTime;

        // Constructor

        public Movie(string director, string title, int numCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            this.NumCopies = numCopies;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nMovie ----- ");
            Console.WriteLine(" Director: {0}", director);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", playTime);
        }
    }

    public abstract class Transform : LibraryItem
    {
        protected LibraryItem libraryItem;

        // Implement this class


    }

    public class Borrowable : Transform
    {
        protected readonly List<string> borrowers = new List<string>();

        // Implement this class


    }
}