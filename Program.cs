using System;
using NLog;
using System.Linq;

namespace MovieLINQ
{
    class MainClass
    {
        // create a class level instance of logger (can be used in methods other than Main)
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            logger.Info("Program started");

            string scrubbedFile = FileScrubber.ScrubMovies("../../movies.csv");
            MovieFile movieFile = new MovieFile(scrubbedFile);

            Console.WriteLine("Enter search criteria Below ");
            Console.WriteLine("Search by entering title of movie, album or book:");
            string response = Console.ReadLine();

            // LINQ - Where filter operator & Contains quantifier operator
            var Movies = movieFile.Movies.Where(m => m.title.Contains(response));
            // Display Movies List results after operations
            foreach (Movie m in Movies)
            {
                Console.WriteLine(m.Display());
            }
            // LINQ - Count aggregation method
            Console.WriteLine();
            Console.WriteLine($"There are {Movies.Count()} in your search");

            logger.Info("Program ended");
        }
    }
}
