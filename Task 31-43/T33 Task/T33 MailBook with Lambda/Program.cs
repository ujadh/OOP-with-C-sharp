using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JAMK.IT.TTC8440
{
    public class Friend
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Friend(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class MailBook
    {
        private readonly List<Friend> friends;

        public IReadOnlyList<Friend> Friends => friends;

        public MailBook()
        {
            friends = LoadFriendsFromFile("Friends.csv");
        }

        private List<Friend> LoadFriendsFromFile(string filePath)
        {
            List<Friend> loadedFriends = new List<Friend>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        var friend = new Friend(parts[0], parts[1]);
                        loadedFriends.Add(friend);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found. Creating a new file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading friends: {ex.Message}");
            }

            return loadedFriends;
        }

        public void SaveFriendToFile(Friend newFriend, string filePath)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{newFriend.Name},{newFriend.Email}");
                }

                friends.Add(newFriend);
                Console.WriteLine($"Friend '{newFriend.Name}' added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving friend: {ex.Message}");
            }
        }

        public List<Friend> SearchFriends(string searchTerm)
        {
            return friends
                .Where(friend => friend.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }

    class Program
    {
        static void Main()
        {
            MailBook mailBook = new MailBook();

            Console.WriteLine($"{mailBook.Friends.Count} names in the address book:");
            foreach (var friend in mailBook.Friends)
            {
                Console.WriteLine(friend.Name);
            }

            Console.Write("\nEnter the name or part of the name of the person you are looking for > ");
            string searchInput = Console.ReadLine();

            List<Friend> searchResults = mailBook.SearchFriends(searchInput);

            Console.WriteLine("\nSearch Results:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"{result.Name} {result.Email}");
            }

            // Example of adding a new friend
            Console.WriteLine("\nAdding a new friend:");
            Friend newFriend = new Friend("John Doe", "john.doe@example.com");
            mailBook.SaveFriendToFile(newFriend, "Friends.csv");

            Console.WriteLine("\nProgram completed successfully. Press any key to continue...");
            Console.ReadLine(); // To keep the console window open
        }
    }
}