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
            return $"{FirstName} {LastName} (#{Number}) - {GameLocation}";
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
                    new Player("Player1", "JYP", "Home", 1),
                    new Player("Player2", "JYP", "Away", 2),
                    new Player("Player3", "JYP", "Home", 3)
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

            // Add a player to JYP
            teams.First(t => t.Name.ToLower() == "jyp").Players.Add(new Player("NewPlayer", "JYP", "Home", 7));

            Console.WriteLine("\nAfter Adding a Player to JYP:");
            DisplayTeamsAndPlayers(teams);

            // Delete a player from Ilves
            var ilvesTeam = teams.First(t => t.Name.ToLower() == "ilves");
            var playerToRemove = ilvesTeam.Players.FirstOrDefault(p => p.Number == 5);
            if (playerToRemove != null)
            {
                ilvesTeam.Players.Remove(playerToRemove);
            }

            Console.WriteLine("\nAfter Deleting a Player from Ilves:");
            DisplayTeamsAndPlayers(teams);
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