using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class Human
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public Human(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }

    public class Director : Human
    {
        public Director(string name, int birthYear) : base(name, birthYear)
        {
        }
    }

    public class Actor : Human
    {
        public Actor(string name, int birthYear) : base(name, birthYear)
        {
        }
    }

    public class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Director Director { get; }
        public List<Actor> Actors { get; }

        public Movie(string name, int year, Director director, List<Actor> actors)
        {
            Name = name;
            Year = year;
            Director = director;
            Actors = actors;
        }

        public void DisplayMovieInfo()
        {
            Console.WriteLine($"Movie: {Name} ({Year})");
            Console.WriteLine($"Director: {Director.Name} ({Director.BirthYear})");

            Console.WriteLine("Actors:");
            foreach (var actor in Actors)
            {
                Console.WriteLine($"- {actor.Name} ({actor.BirthYear})");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a director
            Director director1 = new Director("Christopher Nolan", 1970);

            // Create actors
            Actor actor1 = new Actor("Leonardo DiCaprio", 1974);
            Actor actor2 = new Actor("Joseph Gordon-Levitt", 1981);

            // Create a movie
            Movie inception = new Movie("Inception", 2010, director1, new List<Actor> { actor1, actor2 });

            // Display movie information
            inception.DisplayMovieInfo();

            // Create another director
            Director director2 = new Director("Quentin Tarantino", 1963);

            // Create more actors
            Actor actor3 = new Actor("Brad Pitt", 1963);
            Actor actor4 = new Actor("Margot Robbie", 1990);

            // Create another movie
            Movie onceUponATime = new Movie("Once Upon a Time in Hollywood", 2019, director2, new List<Actor> { actor3, actor4 });

            // Display movie information
            onceUponATime.DisplayMovieInfo();
        }
    }
}