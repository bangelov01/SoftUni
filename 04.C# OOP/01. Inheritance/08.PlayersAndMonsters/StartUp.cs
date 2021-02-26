using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster soulMaster = new SoulMaster("Ludiq", 24);

            Console.WriteLine(soulMaster);
        }
    }
}