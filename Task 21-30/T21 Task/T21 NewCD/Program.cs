using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440

{

    public class Song
    {
        public string Name { get; set; }
        public TimeSpan Length { get; set; }

        public Song(string name, TimeSpan length)
        {
            Name = name;
            Length = length;
        }
    }

    public class CD
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public List<Song> Songs { get; set; }

        public int NumberOfSongs => Songs.Count;
        public TimeSpan TotalLength => Songs.Aggregate(TimeSpan.Zero, (acc, song) => acc + song.Length);

        public CD(string name, string artist)
        {
            Name = name;
            Artist = artist;
            Songs = new List<Song>();
        }

        public void AddSong(string name, int minutes, int seconds)
        {
            Songs.Add(new Song(name, new TimeSpan(0, minutes, seconds)));
        }

        public void PrintCDInfo()
        {
            Console.WriteLine($"You have a CD:");
            Console.WriteLine($"- Name: {Name}");
            Console.WriteLine($"- Artist: {Artist}");
            Console.WriteLine($"- Total Length: {TotalLength.TotalMinutes} min {TotalLength.Seconds} sec");
            Console.WriteLine($"- {NumberOfSongs} songs:");

            foreach (var song in Songs)
            {
                Console.WriteLine($"  - {song.Name}, {song.Length.Minutes}:{song.Length.Seconds:D2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            CD myCD = new CD("Endless Forms Most Beautiful", "Nightwish");

            myCD.AddSong("Shudder Before the Beautiful", 6, 29);
            myCD.AddSong("Weak Fantasy", 5, 23);
            myCD.AddSong("Elan", 4, 45);
            myCD.AddSong("Yours Is an Empty Hope", 5, 34);
            myCD.AddSong("Our Decades in the Sun", 6, 37);
            myCD.AddSong("My Walden", 4, 38);
            myCD.AddSong("Endless Forms Most Beautiful", 5, 7);
            myCD.AddSong("Edema Ruh", 5, 15);
            myCD.AddSong("Alpenglow", 4, 45);
            myCD.AddSong("The Eyes of Sharbat Gula", 6, 3);
            myCD.AddSong("The Greatest Show on Earth", 24, 0);

            myCD.PrintCDInfo();
        }
    }
}