using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class CD
    {
        // Properties
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public List<(string, string)> Songs { get; set; } // Using tuples for song name and duration

        // Constructor
        public CD(string artist, string name, string genre, double price)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            Songs = new List<(string, string)>();
        }

        // Method to add a song to the CD
        public void AddSong(string songName, string duration)
        {
            Songs.Add((songName, duration));
        }

        // Method to display CD information and songs
        public string GetCDInfo()
        {
            string cdInfo = $"CD:\n" +
                            $"    -Artist: {Artist}\n" +
                            $"    -Name: {Name}\n" +
                            $"    -Genre: {Genre}\n" +
                            $"    -Price: ${Price:F1}\n" +
                            "Songs:\n";

            foreach (var (songName, duration) in Songs)
            {
                cdInfo += $"--- Name: {songName} - {duration}\n";
            }

            return cdInfo;
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a CD object
            CD myCD = new CD("Random Artist", "Awesome Album", "Rock Fusion", 14.99);

            // Add songs to the CD
            myCD.AddSong("Song 1", "04:30");
            myCD.AddSong("Song 2", "03:45");
            myCD.AddSong("Song 3", "05:12");
            myCD.AddSong("Song 4", "04:02");
            myCD.AddSong("Song 5", "06:20");

            // Display CD information
            Console.WriteLine(myCD.GetCDInfo());
        }
    }
}