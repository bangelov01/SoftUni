using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._ThePianist
{
    class Pieces
    {
        public Pieces(string composer, string key)
        {
            Composer = composer;
            Key = key;
        }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPieces = int.Parse(Console.ReadLine());

            Dictionary<string, Pieces> piecesDic = new Dictionary<string, Pieces>();

            while (numOfPieces > 0)
            {
                string[] firstPieces = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string piece = firstPieces[0];
                string composer = firstPieces[1];
                string key = firstPieces[2];

                piecesDic.Add(piece, new Pieces(composer, key));

                numOfPieces--;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArr = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArr[0];
                string piece = commandArr[1];

                if (action == "Add")
                {
                    string composer = commandArr[2];
                    string key = commandArr[3];

                    if (!piecesDic.ContainsKey(piece))
                    {
                        piecesDic.Add(piece, new Pieces(composer, key));
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (!piecesDic.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        piecesDic.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = commandArr[2];

                    if (piecesDic.ContainsKey(piece))
                    {
                        piecesDic[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in piecesDic.OrderBy(x => x.Key).ThenBy(x => x.Value.Composer))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}
