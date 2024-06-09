using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameLocation { get; set; }
        public int Number { get; set; }

        public Player(string firstName, string lastName, string gameLocation, int number)
        {
            FirstName = firstName;
            LastName = lastName;
            GameLocation = gameLocation;
            Number = number;
        }

        public override string ToString()
        {
            return $"{FirstName};{LastName};{GameLocation};{Number}";
        }
    }

    public class Team
    {
        public string Name { get; }
        public string Hometown { get; }
        public List<Player> Players { get; }

        public Team(string team)
        {
            Name = team;
            Hometown = GetHometown(team);
            Players = GetDefaultPlayers(team);
        }

        private string GetHometown(string team)
        {
            // Add more teams and their hometowns as needed
            switch (team.ToLower())
            {
                case "jyp":
                    return "Jyväskylä";
                case "ilves":
                    return "Tampere";
                // Add more cases for other teams
                default:
                    return "Unknown";
            }
        }

        private List<Player> GetDefaultPlayers(string team)
        {
            // Add more teams and their default players as needed
            switch (team.ToLower())
            {
                case "jyp":
                    return new List<Player>
                {
                    new Player("Jarkko", "Immonen", "center", 26),
                    new Player("Brad", "Lambert", "forward", 16)
                    // Add more players as needed
                };
                case "ilves":
                    return new List<Player>
                {
                    new Player("Player4", "Ilves", "Away", 4),
                    new Player("Player5", "Ilves", "Home", 5),
                    new Player("Player6", "Ilves", "Away", 6)
                    // Add more players as needed
                };
                // Add more cases for other teams
                default:
                    return new List<Player>();
            }
        }

        public void SavePlayersToCsv()
        {
            string fileName = $"{Name}.csv";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var player in Players)
                {
                    writer.WriteLine(player.ToString());
                }
            }

            Console.WriteLine($"Players of {Name} saved to {fileName}");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Team> teams = new List<Team>
        {
            new Team("JYP"),
            new Team("Ilves")
            // Add more teams as needed
        };

            Console.WriteLine("SMLiiga Teams and Players:");
            DisplayTeamsAndPlayers(teams);

            // Save JYP players to a CSV file
            teams.First(t => t.Name.ToLower() == "jyp").SavePlayersToCsv();

            // Save Ilves players to a CSV file
            teams.First(t => t.Name.ToLower() == "ilves").SavePlayersToCsv();
        }

        static void DisplayTeamsAndPlayers(List<Team> teams)
        {
            foreach (var team in teams)
            {
                Console.WriteLine($"{team.Name} ({team.Hometown}):");
                foreach (var player in team.Players)
                {
                    Console.WriteLine($"  {player}");
                }
                Console.WriteLine();
            }
        }
    }
}