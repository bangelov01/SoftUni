using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationsRepo;
        private List<IAquarium> aquariumsCollection;

        public Controller()
        {
            decorationsRepo = new DecorationRepository();
            aquariumsCollection = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            this.aquariumsCollection.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }

            this.decorationsRepo.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            var neededAquarium = this.aquariumsCollection.FirstOrDefault(a => a.Name == aquariumName);

            if (neededAquarium is FreshwaterAquarium && fish is SaltwaterFish)
            {
                return OutputMessages.UnsuitableWater;
            }
            else if (neededAquarium is FreshwaterAquarium && fish is FreshwaterFish)
            {
                neededAquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (neededAquarium is SaltwaterAquarium && fish is FreshwaterFish)
            {
                return OutputMessages.UnsuitableWater;
            }
            else if (neededAquarium is SaltwaterAquarium && fish is SaltwaterFish)
            {
                neededAquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return "Something Went Wrong!"; //CHECK
        }

        public string CalculateValue(string aquariumName)
        {
            var neededAquarium = this.aquariumsCollection.FirstOrDefault(a => a.Name == aquariumName);

            var fishSum = neededAquarium.Fish.Sum(f => f.Price);
            var decorationSum = neededAquarium.Decorations.Sum(f => f.Price);

            var total = fishSum + decorationSum;

            return string.Format(OutputMessages.AquariumValue, aquariumName, total);
        }

        public string FeedFish(string aquariumName)
        {
            var neededAquarium = this.aquariumsCollection.FirstOrDefault(a => a.Name == aquariumName);

            int fedCount = 0;

            foreach (var fish in neededAquarium.Fish)
            {
                fish.Eat();
                fedCount++;
            }

            return string.Format(OutputMessages.FishFed, fedCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var neededDecoration = this.decorationsRepo.FindByType(decorationType);

            if (neededDecoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var neededAquarium = aquariumsCollection.FirstOrDefault(a => a.Name == aquariumName);

            neededAquarium.AddDecoration(neededDecoration);

            this.decorationsRepo.Remove(neededDecoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariumsCollection)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
