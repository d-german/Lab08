using System;
using System.Linq;

namespace Baseball
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new BaseballEntities();

            var jack = db.Players.FirstOrDefault(p => p.FirstName.Equals("Jack"));
            if (jack != null) jack.LastName = "ZZZZ";

            var player = new Player {FirstName = "George", LastName = "Brett", BattingAverage = .999m};

            db.Players.Add(player);
            db.SaveChanges();

            foreach (var dbPlayer in db.Players)
            {
                Console.WriteLine($"{dbPlayer.FirstName} {dbPlayer.LastName} {dbPlayer.BattingAverage}");
            }

            Console.WriteLine();

            db.Players.Remove(player);
            db.SaveChanges();

            foreach (var dbPlayer in db.Players)
            {
                Console.WriteLine($"{dbPlayer.FirstName} {dbPlayer.LastName} {dbPlayer.BattingAverage}");
            }
        }
    }
}