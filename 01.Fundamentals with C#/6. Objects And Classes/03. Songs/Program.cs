using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songData = Console.ReadLine().Split("_");

                string typeList = songData[0];
                string songName = songData[1];
                string songTime = songData[2];

                Song song = new Song();

                song.TypeList = typeList;
                song.Name = songName;
                song.Time = songTime;

                songs.Add(song);
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filtered = songs.Where(x => x.TypeList == command).ToList();

                foreach (Song song in filtered)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
