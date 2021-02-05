using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Trainer> trainers = new List<Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = commandArr[0];
                string pokemonName = commandArr[1];
                string pokemonElement = commandArr[2];
                int pokemonHealth = int.Parse(commandArr[3]);

                Pokemon newPokemon = new Pokemon(pokemonName,pokemonElement, pokemonHealth);

                Trainer newTrainer = new Trainer(trainerName);

                if (!trainers.Exists(x => x.Name == trainerName))
                {
                    newTrainer.Pokemon.Add(newPokemon);
                    trainers.Add(newTrainer);
                }
                else
                {
                    Trainer addPoke = trainers.Find(x => x.Name == trainerName);
                    addPoke.Pokemon.Add(newPokemon);
                }
            }

            string commandPokemon = string.Empty;

            while ((commandPokemon = Console.ReadLine()) != "End")
            {
                Func<Trainer, bool> isContained = CheckContainment(commandPokemon);

                foreach (var trainer in trainers)
                {
                    if (isContained(trainer))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemon.ForEach(x => x.Health -= 10);
                        trainer.Pokemon.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges).Distinct())
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
            }
        }

        public static Func<Trainer, bool> CheckContainment (string command)
        {
            return p => p.Pokemon.Any(x => x.Element == command);
        }
    }
}
