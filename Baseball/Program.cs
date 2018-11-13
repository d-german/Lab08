using System;
using System.Linq;

namespace Baseball
{
    internal class Program
    {
        static readonly BaseballEntities Db = new BaseballEntities();

        private static void Main(string[] args)
        {
            //display the database
            DisplayPlayers();

            //find and update a player
            var existingPlayer = Db.Players.FirstOrDefault(p => p.FirstName.Equals("Jack"));
            if (existingPlayer != null) existingPlayer.LastName = "ZZZZ";

            //Add a new player
            var newPlayer = new Player {FirstName = "George", LastName = "Brett", BattingAverage = .999m};
            Db.Players.Add(newPlayer);

            //Must save changes to the database
            Db.SaveChanges();

            //display the database, note the new player
            DisplayPlayers();

            //Remove the previously added player
            Db.Players.Remove(newPlayer);
            //Must save the changes to the database
            Db.SaveChanges();

            //Display the database, note the new player is gone.
            DisplayPlayers();

            DisplayPlayers(p => p.LastName == "ZZZZ");
        }

        private static void DisplayPlayers(Func<Player, bool> predicate = null)
        {
            Console.WriteLine();

            predicate = predicate ?? (p => p != null);

            foreach (var dbPlayer in Db.Players.Where(predicate))
            {
                Console.WriteLine($"\t{dbPlayer.FirstName,-10} {dbPlayer.LastName,-10} {dbPlayer.BattingAverage,-10}");
            }

            Console.WriteLine();
        }
    }
}